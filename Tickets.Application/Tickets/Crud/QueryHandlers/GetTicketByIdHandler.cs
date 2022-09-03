using MediatR;
using Tickets.Application.Enums;
using Tickets.Application.Models.Common;
using Tickets.Application.Tickets.Crud.Queries;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Crud.QueryHandlers;

public class GetTicketByIdHandler : IRequestHandler<GetTicketById, OperationResult<Ticket>>
{
    private readonly IQueryRepositoryWrapper _qryRepo;

    public GetTicketByIdHandler(IQueryRepositoryWrapper qryRepo)
    {
        _qryRepo = qryRepo;
    }

    public async Task<OperationResult<Ticket>> Handle(GetTicketById request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Ticket>();

        try
        {
            var ticket = await _qryRepo.Ticket.GetTicketWithDetailsByIdAsync(request.Id);
            if (ticket is null)
            {
                result.AddError(new Error(code: ErrorCode.NotFound, message: "Ticket not found"));
                return result;
            }
            result.SetPayload(ticket);

            return result;
        }

        catch (Exception e)
        {
            result.AddError(e);

            return result;
        }
    }
}
