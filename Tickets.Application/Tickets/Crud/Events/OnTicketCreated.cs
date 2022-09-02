using MediatR;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Crud.Events;

public record OnTicketCreated(Ticket Ticket) : INotification;
