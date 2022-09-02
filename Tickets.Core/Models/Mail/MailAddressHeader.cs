namespace Tickets.Core.Models.Mail;
public class MailAddressEntry
{
   public IList<MailAddress> To { get; } = new List<MailAddress>();
   public IList<MailAddress> Cc { get; } = new List<MailAddress>();
   public IList<MailAddress> Bcc { get; } = new List<MailAddress>();
}
