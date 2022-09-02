using Tickets.Core.Models.Mail;

namespace Tickets.Core.Abstractions;
public interface IMailService
{
   IList<MailMessage> GenerateMailMessages(IList<MailAddressHeader> mailAddressHeaders, MailContent mailContent);
   Task<IList<MailMessage>> SendMailMessagesGetFailedAsync(IList<MailMessage> mailMessagesToSend);
}
