using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions.Mail;

public interface IMailSender
{
   bool SendEmail(MailMessage message);
   Task<bool> SendEmailAsync(MailMessage message);
}
