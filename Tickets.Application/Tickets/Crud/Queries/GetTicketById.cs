using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Crud.Queries;

public record GetTicketById(Guid Id) : IRequest<OperationResult<Ticket>>;
