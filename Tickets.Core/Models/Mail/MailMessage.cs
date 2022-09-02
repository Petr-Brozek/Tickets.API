namespace Tickets.Core.Models.Mail;

public class MailMessage
{
   public IList<MailAddress> To { get; } = new List<MailAddress>();
   public IList<MailAddress> Cc { get; } = new List<MailAddress>();
   public IList<MailAddress> Bcc { get; } = new List<MailAddress>();
   public string Subject { get; } = string.Empty;
   public string Body { get; } = string.Empty;

   private MailMessage()
   {

   }
   public MailMessage(MailAddressEntry mailAddressHeader, MailContent mailContent)
   {
      To = mailAddressHeader.To;
      Cc = mailAddressHeader.Cc;
      Bcc = mailAddressHeader.Bcc;
      Subject = mailContent.Subject;
      Body = mailContent.Body;
   }
}
