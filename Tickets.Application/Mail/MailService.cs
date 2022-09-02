using MediatR;
using Tickets.Application.Mail.Commands;
using Tickets.Core.Abstractions;
using Tickets.Core.Models.Mail;

namespace Tickets.Application.Mail;
public class MailService : IMailService
{
    private readonly IMediator _mediator;

    public MailService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<MailMessage>> SendMailMessagesGetFailedAsync(IList<MailMessage> mailMessages)
    {
        var failedMailMessages = new List<MailMessage>();
        foreach (var mailMessage in mailMessages)
        {
            var sendMailResult = await _mediator.Send(new SendMail(mailMessage));
            if (sendMailResult.IsError)
            {
                failedMailMessages.Add(mailMessage);
            }
        }
        return failedMailMessages;
    }

    public IList<MailMessage> GenerateMailMessages(IList<MailAddressHeader> mailAddressHeaders, MailContent mailContent)
    {
        var mailMessages = new List<MailMessage>();
        foreach (var mailAddressHeader in mailAddressHeaders)
        {
            var mailMessage = new MailMessage(mailAddressHeader, mailContent);
            mailMessages.Add(mailMessage);
        }
        return mailMessages;
    }
}
