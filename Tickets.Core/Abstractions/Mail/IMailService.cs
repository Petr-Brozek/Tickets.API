using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions.Mail;
public interface IMailService
{
    Task<IEnumerable<MailMessage>> SendMailMessagesGetFailedAsync(IEnumerable<MailMessage> mailMessagesToSend);
}
