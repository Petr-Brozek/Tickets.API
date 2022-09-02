using MediatR;
using Tickets.Application.Enums;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Commands;
using Tickets.Core.Abstractions.Repositories.CmdRepo;
using Tickets.Core.Abstractions.Repositories.QryRepo;

namespace Tickets.Application.Tickets.CommandHandlers;

public class ChangeTicketStateHandler : IRequestHandler<ChangeTicketState, OperationResult<Unit>>
{
   private readonly IQueryRepositoryWrapper _qryRepo;
   private readonly ICommandRepositoryWrapper _cmpRepo;

   public ChangeTicketStateHandler(IQueryRepositoryWrapper qryRepo, ICommandRepositoryWrapper cmdRepo)
   {
      _qryRepo = qryRepo;
      _cmpRepo = cmdRepo;
   }

   public async Task<OperationResult<Unit>> Handle(ChangeTicketState request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      try
      {
         var ticket = await _qryRepo.Ticket.GetTicketWithDetailsByIdAsync(request.TicketId);
         if (ticket is null)
         {
            result.AddError(new Error(ErrorCode.NotFound, $"Ticket not found"));
         }

         var newState = await _qryRepo.TicketState.GetTicketStateByNameAsync(request.NewStateName);
         if (newState is null)
         {
            result.AddError(new Error(ErrorCode.NotFound, $"New state not found"));
         }

         ticket!.UpdateTicketState(newState!);
         _cmpRepo.Ticket.UpdateTicket(ticket);
         await _cmpRepo.SaveAsync();

         return result;
      }

      catch (Exception e)
      {
         result.AddError(e);

         return result;
      }
   }
}
