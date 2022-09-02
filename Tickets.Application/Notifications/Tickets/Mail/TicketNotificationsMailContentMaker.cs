using Tickets.Core.Abstractions;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Models.Mail;

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
