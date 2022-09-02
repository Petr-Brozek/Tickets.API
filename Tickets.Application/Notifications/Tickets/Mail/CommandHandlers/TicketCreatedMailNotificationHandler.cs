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
         var mailAddressEntries = await GenerateMailAddressEntriesAsync(GetProperSubscriptions(request.Ticket));
         var mailMessages = mailAddressEntries.Select(mah => new MailMessage(mah, mailContent));

         foreach (var mailMessage in mailMessages)
         {
            if (!await _mailSender.SendEmailAsync(mailMessage))
            {
               result.AddWarning(new Warning($"Sending mail failed. Message: {JsonSerializer.Serialize(mailMessage)}"));
            }
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

   private async Task<List<MailAddressEntry>> GenerateMailAddressEntriesAsync(IEnumerable<TicketSubscription> subscriptions)
   {
      var mailAddressEntries = new List<MailAddressEntry>();
      foreach (var subscription in subscriptions)
      {
         var mailAddressEntry = new MailAddressEntry();
         var subscriberUserProfile = await _qryRepo.UserProfile.GetUserProfileWithDetailsByIdAsync(subscription.SubscriberUserProfileId);
         if (subscriberUserProfile != null)
         {
            mailAddressEntry.To.Add(new MailAddress(subscriberUserProfile.BasicInfo.FirstName,
               subscriberUserProfile.BasicInfo.EmailAddress));
         }
         else
         {
            // TO DO:  Handle error
         }
         mailAddressEntries.Add(mailAddressEntry);
      }
      return mailAddressEntries;
   }
}
