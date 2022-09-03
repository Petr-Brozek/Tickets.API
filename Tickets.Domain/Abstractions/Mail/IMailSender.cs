using Tickets.Domain.Models.Mail;

namespace Tickets.Domain.Abstractions.Mail;

public interface IMailSender
{
   bool SendEmail(MailMessage message);
   Task<bool> SendEmailAsync(MailMessage message);
}
