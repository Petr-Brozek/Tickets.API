using MediatR;
using Microsoft.EntityFrameworkCore;
using Tickets.Application.Identity.Queries;
using Tickets.Application.Models.Common;
using Tickets.Core.Aggregates.UserProfileAggregate;
using Tickets.Infrastructure.Dal;

namespace Tickets.Application.Identity.QueryHandlers;

public class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, OperationResult<UserProfile>>
{
   private readonly DataContext _ctx;

   public GetUserProfileByIdHandler(DataContext ctx)
   {
      _ctx = ctx;
   }

   public async Task<OperationResult<UserProfile>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<UserProfile>();

      try
      {
         var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.Id);

         if (userProfile == null)
         {
            var error = new Error(Enums.ErrorCode.NotFound, "User profile not found");
            result.AddError(error);

            return result;
         }

         result.SetPayload(userProfile);
      }

      catch (Exception e)
      {
         result.AddError(e);
      }

      return result;
   }
}
