using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions.Mail;

public interface IMailSender
{
    void SendEmail(MailMessage message);
    Task SendEmailAsync(MailMessage message);
}
