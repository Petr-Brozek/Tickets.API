using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Crud.Queries;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Crud.QueryHandlers;

public class GetAllTicketsHandler : IRequestHandler<GetAllTickets, OperationResult<IEnumerable<Ticket>>>
{
    private readonly IQueryRepositoryWrapper _qryRepo;

    public GetAllTicketsHandler(IQueryRepositoryWrapper qryRepo)
    {
        _qryRepo = qryRepo;
    }

    public async Task<OperationResult<IEnumerable<Ticket>>> Handle(GetAllTickets request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<IEnumerable<Ticket>>();

        try
        {
            var tickets = await _qryRepo.Ticket.GetAllTicketsAsync();
            result.SetPayload(tickets);

            return result;
        }
        catch (Exception e)
        {
            result.AddError(e);

            return result;
        }
    }
}
