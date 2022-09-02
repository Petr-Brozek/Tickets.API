using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions.Notifications.Tickets;
public interface ITicketNotificationsMailContentMaker
{
    public MailContent TicketCreated(Ticket ticket);
}
