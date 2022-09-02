
using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions;

public interface IMailSender
{
   void SendEmail(MailMessage message);
   Task SendEmailAsync(MailMessage message);
}
