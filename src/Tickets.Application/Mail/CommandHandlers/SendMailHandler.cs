using MediatR;
using Tickets.Application.Mail.Commands;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Mail.CommandHandlers;
public class SendMailHandler : IRequestHandler<SendMail, OperationResult<Unit>>
{
   public Task<OperationResult<Unit>> Handle(SendMail request, CancellationToken cancellationToken)
   {
      throw new NotImplementedException();
   }
}
