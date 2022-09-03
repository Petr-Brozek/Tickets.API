using MediatR;
using Tickets.Application.Notifications.Tickets.Mail.Commands;
using Tickets.Application.Tickets.Crud.Events;

namespace Tickets.Application.Tickets.Crud.EventHandlers;
public class OnTicketCreatedHandler : INotificationHandler<OnTicketCreated>
{
    private readonly IMediator _mediator;

    public OnTicketCreatedHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(OnTicketCreated notification, CancellationToken cancellationToken)
    {
        await _mediator.Send(new TicketCreatedMailNotification(notification.Ticket));
    }
}
