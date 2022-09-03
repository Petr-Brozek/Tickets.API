using MediatR;
using Microsoft.AspNetCore.Identity;
using Tickets.Application.Definitions.Identity;
using Tickets.Application.Enums;
using Tickets.Application.Identity.Commands;
using Tickets.Application.Models.Common;
using Tickets.Domain.Aggregates.UserProfileAggregate;
using Tickets.Infrastructure.Dal;

namespace Tickets.Application.Identity.CommandHandlers;

public class RegisterHandler : IRequestHandler<Register, OperationResult<Unit>>
{
   private readonly DataContext _ctx;
   private readonly UserManager<IdentityUser> _userManager;
   private readonly RoleManager<IdentityRole> _roleManager;

   public RegisterHandler(DataContext ctx, UserManager<IdentityUser> userManager,
      RoleManager<IdentityRole> roleManager)
   {
      _ctx = ctx;
      _userManager = userManager;
      _roleManager = roleManager;
   }

   public async Task<OperationResult<Unit>> Handle(Register request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      using var transaction = await _ctx.Database.BeginTransactionAsync(cancellationToken);
      try
      {
         var userExists = await _userManager.FindByNameAsync(request.EmailAddress);
         if (userExists != null)
         {
            result.AddError(new Error(code: ErrorCode.ServerError, message: "User already exists"));

            return result;
         }

         var user = new IdentityUser()
         {
            Email = request.EmailAddress,
            UserName = request.EmailAddress,
            SecurityStamp = Guid.NewGuid().ToString(),
         };

         var res = await _userManager.CreateAsync(user, request.Password);

         if (!res.Succeeded)
         {
            await transaction.RollbackAsync(cancellationToken);

            result.AddError(new Error(code: ErrorCode.ServerError,
               message: "User creation failed.  Please check user details and try again."));

            return result;
         }

         await PopulateUserWithRoles(user);

         var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress);
         var userProfile = UserProfile.CreateUserProfile(user.Id, basicInfo);

         _ctx.UserProfiles.Add(userProfile);
         await _ctx.SaveChangesAsync(cancellationToken);

         await transaction.CommitAsync(cancellationToken);

         return result;
      }

      catch (Exception e)
      {
         await transaction.RollbackAsync(cancellationToken);

         result.AddError(e);

         return result;
      }
   }

   private async Task PopulateUserWithRoles(IdentityUser user)
   {
      if (!await _roleManager.RoleExistsAsync(UserRoles.User))
         await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
      if (!await _roleManager.RoleExistsAsync(UserRoles.CanCreateTicket))
         await _roleManager.CreateAsync(new IdentityRole(UserRoles.CanCreateTicket));
      if (!await _roleManager.RoleExistsAsync(UserRoles.CanCreateTicketComment))
         await _roleManager.CreateAsync(new IdentityRole(UserRoles.CanCreateTicketComment));
      if (!await _roleManager.RoleExistsAsync(UserRoles.CanEditTicketComment))
         await _roleManager.CreateAsync(new IdentityRole(UserRoles.CanEditTicketComment));

      await _userManager.AddToRoleAsync(user, UserRoles.User);
      await _userManager.AddToRoleAsync(user, UserRoles.CanCreateTicket);
      await _userManager.AddToRoleAsync(user, UserRoles.CanCreateTicketComment);
   }
}
