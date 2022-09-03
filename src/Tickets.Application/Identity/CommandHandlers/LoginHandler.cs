using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tickets.Application.Enums;
using Tickets.Application.Identity.Commands;
using Tickets.Application.Models.Common;
using Tickets.Application.Models.Identity;
using Tickets.Infrastructure.Dal;

namespace Tickets.Application.Identity.CommandHandlers;

public class LoginHandler : IRequestHandler<Login, OperationResult<GeneratedJwtToken>>
{
   private readonly DataContext _ctx;
   private readonly UserManager<IdentityUser> _userManager;
   private readonly IConfiguration _configuration;

   public LoginHandler(DataContext ctx, UserManager<IdentityUser> userManager,
      IConfiguration configuration)
   {
      _ctx = ctx;
      _userManager = userManager;
      _configuration = configuration;
   }

   public async Task<OperationResult<GeneratedJwtToken>> Handle(Login request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<GeneratedJwtToken>();

      try
      {
         var user = await _userManager.FindByNameAsync(request.UserName);
         // TO DO:  Chnage to qryRepo
         if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
         {
            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.IdentityId == user.Id,
              cancellationToken: cancellationToken);
            if (userProfile == null)
            {
               result.AddError(new Error(code: ErrorCode.NotFound, message: "User profile not found"));
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>()
            {
               new Claim(ClaimTypes.Name, request.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("UserId", user.Id),
               new Claim("UserProfileId", userProfile!.UserProfileId.ToString()),
            };

            foreach (var userRole in userRoles)
            {
               authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            var tokenResult = new GeneratedJwtToken
            {
               Token = new JwtSecurityTokenHandler().WriteToken(token),
               ValidTo = token.ValidTo
            };

            result.SetPayload(tokenResult);

            return result;
         }

         result.AddError(new Error(code: ErrorCode.Unauthorized, message: "Authorization failed"));

         return result;
      }

      catch (Exception e)
      {
         result.AddError(e);

         return result;
      }
   }

   private JwtSecurityToken GetToken(List<Claim> authClaims)
   {
      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

      var token = new JwtSecurityToken(
          issuer: _configuration["JWT:ValidIssuer"],
          audience: _configuration["JWT:ValidAudience"],
          expires: DateTime.Now.AddHours(3),
          claims: authClaims,
          signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
          );

      return token;
   }
}
