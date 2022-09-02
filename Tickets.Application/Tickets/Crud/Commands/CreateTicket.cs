using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Commands;

public record CreateTicket(string Summary, Guid CreatedByUserProfileId)
   : IRequest<OperationResult<Ticket>>;
