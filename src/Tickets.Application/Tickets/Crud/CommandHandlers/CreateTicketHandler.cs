using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Commands;
using Tickets.Application.Tickets.Crud.Events;
using Tickets.Domain.Abstractions.Repositories.CmdRepo;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.CommandHandlers;

public class CreateTicketHandler : IRequestHandler<CreateTicket, OperationResult<Ticket>>
{
   private readonly ICommandRepositoryWrapper _cmdRepo;
   private IMediator _mediator;

   public CreateTicketHandler(ICommandRepositoryWrapper cmdRepo, IMediator mediator)
   {
      _cmdRepo = cmdRepo;
      _mediator = mediator;
   }

   public async Task<OperationResult<Ticket>> Handle(CreateTicket request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Ticket>();

      try
      {
         var ticketToCreate = Ticket.CreateTicket(request.Summary, request.CreatedByUserProfileId);    // TO DO: Validate CreatedByUserProfileId

         _cmdRepo.Ticket.Create(ticketToCreate);
         await _cmdRepo.SaveAsync();

         await _mediator.Publish(new OnTicketCreated(ticketToCreate), cancellationToken);

         result.SetPayload(ticketToCreate);

         return result;
      }

      catch (Exception e)
      {
         result.AddError(e);

         return result;
      }
   }
}
