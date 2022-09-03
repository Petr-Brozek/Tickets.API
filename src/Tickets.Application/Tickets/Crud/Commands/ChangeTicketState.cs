using MediatR;
using Tickets.Application.Models.Common;

namespace Tickets.Application.Tickets.Commands;

public record ChangeTicketState(Guid TicketId, string NewStateName) : IRequest<OperationResult<Unit>>;
