using MediatR;
using System.Text.Json;
using Tickets.Application.Models.Common;
using Tickets.Application.Notifications.Tickets.Mail.Commands;
using Tickets.Core.Abstractions.Mail;
using Tickets.Core.Abstractions.Notifications.Tickets;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Enums.Ticket;
using Tickets.Core.Models.Mail;

namespace Tickets.Application.Notifications.Tickets.Mail.CommandHandlers;

public class TicketCreatedMailNotificationHandler : IRequestHandler<TicketCreatedMailNotification, OperationResult<Unit>>
{
   private readonly IQueryRepositoryWrapper _qryRepo;
   private readonly ITicketNotificationsMailContentMaker _mailContentManager;
   private readonly IMailSender _mailSender;

   public TicketCreatedMailNotificationHandler(IQueryRepositoryWrapper qryRepo,
      ITicketNotificationsMailContentMaker mailContentManager, IMailSender mailSender)
   {
      _qryRepo = qryRepo;
      _mailContentManager = mailContentManager;
      _mailSender = mailSender;
   }

   public async Task<OperationResult<Unit>> Handle(TicketCreatedMailNotification request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      try
      {
         var mailContent = _mailContentManager.TicketCreated(request.Ticket);
         var mailAddressHeaders = await GenerateMailAddressHeadersAsync(GetProperSubscriptions(request.Ticket));
         var mailMessages = mailAddressHeaders.Select(mah => new MailMessage(mah, mailContent));

         foreach (var mailMessage in mailMessages)
         {
            await _mailSender.SendEmailAsync(mailMessage);
         }
      }

      catch (Exception e)
      {
         result.AddError(e);
      }

      return result;
   }

   private static IEnumerable<TicketSubscription> GetProperSubscriptions(Ticket ticket)
      => ticket.Subscriptions.Where(s => s.IsActive
            && s.OnTicketAction == TicketSubscriptionAction.OnCreated
            && s.DistrType == TicketSubscriptionDistrType.Mail);

   private async Task<List<MailAddressHeader>> GenerateMailAddressHeadersAsync(IEnumerable<TicketSubscription> subscriptions)
   {
      var mailAddressHeaders = new List<MailAddressHeader>();
      foreach (var subscription in subscriptions)
      {
         var mailAddressHeader = new MailAddressHeader();
         var userProfile = await _qryRepo.UserProfile.GetUserProfileWithDetailsByIdAsync(subscription.SubscriberUserProfileId);
         if (userProfile != null)
         {
            mailAddressHeader.To.Add(new MailAddress(userProfile.BasicInfo.FirstName,
               userProfile.BasicInfo.EmailAddress));
         }
      }
      return mailAddressHeaders;
   }

   private static OperationResult<Unit> RegisterFailedMailMessagesIfAny(OperationResult<Unit> result, IEnumerable<MailMessage> failedMailMessages)
   {
      if (failedMailMessages != null && failedMailMessages.Any())
      {
         foreach (var failedMailMessage in failedMailMessages)
         {
            result.AddWarning(new Warning($"Sending mail failed. Failed message: {JsonSerializer.Serialize(failedMailMessage)}"));
         }
      }

      return result;
   }
}
