using MediatR;
using Tickets.Application.Identity.Commands;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Identity.CommandHandlers;

public class LogoutHandler : IRequestHandler<Logout, OperationResult<Unit>>
{
   public async Task<OperationResult<Unit>> Handle(Logout request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      try
      {
         // TO DO:  Logout logic

         //await _context.HttpContext.SignOutAsync("MyCookieAuth");

         await Task.CompletedTask;
      }

      catch (Exception e)
      {
         result.AddError(e);
      }

      return result;
   }
}
