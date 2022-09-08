using Tickets.Domain.Abstractions.Notifications.Tickets;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Models.Mail;

namespace Tickets.Application.Notifications.Tickets.Mail;

public class TicketNotificationsMailContentMaker : ITicketNotificationsMailContentMaker
{
    public MailContent TicketCreated(Ticket ticket)
    {
        var subject = "New ticket created";
        var body = $"{ticket.Summary}";

        return new MailContent(subject, body);
    }
}