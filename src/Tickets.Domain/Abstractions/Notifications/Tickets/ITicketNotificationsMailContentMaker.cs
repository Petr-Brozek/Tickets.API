using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Models.Mail;

namespace Tickets.Domain.Abstractions.Notifications.Tickets;
public interface ITicketNotificationsMailContentMaker
{
    public MailContent TicketCreated(Ticket ticket);
}
