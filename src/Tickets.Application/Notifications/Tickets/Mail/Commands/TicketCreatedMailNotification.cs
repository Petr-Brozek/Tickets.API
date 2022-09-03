using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Notifications.Tickets.Mail.Commands;

public record TicketCreatedMailNotification(Ticket Ticket) : IRequest<OperationResult<Unit>>;
