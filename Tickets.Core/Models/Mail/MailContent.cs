namespace Tickets.Core.Models.Mail;
public class MailContent
{
   public MailContent(string subject, string body)
   {
      Subject = subject;
      Body = body;
   }

   public string Subject { get; }
   public string Body { get; }
}
