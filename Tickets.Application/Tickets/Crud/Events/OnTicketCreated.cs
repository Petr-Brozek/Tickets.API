using MediatR;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Crud.Events;

public record OnTicketCreated(Ticket Ticket) : INotification;
