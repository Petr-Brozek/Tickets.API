using MediatR;
using Tickets.Application.Models.Common;
using Tickets.Application.Notifications.Tickets.Mail.Commands;
using Tickets.Core.Abstractions;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Enums.Ticket;
using Tickets.Core.Models.Mail;

namespace Tickets.Application.Notifications.Tickets.Mail.CommandHandlers;

public class TicketCreatedMailNotificationHandler : IRequestHandler<TicketCreatedMailNotification, OperationResult<Unit>>
{
   private readonly IQueryRepositoryWrapper _qryRepo;
   private readonly ITicketNotificationsMailContentMaker _mailContentManager;
   private readonly IMailService _mailService;

   public TicketCreatedMailNotificationHandler(IQueryRepositoryWrapper qryRepo,
      ITicketNotificationsMailContentMaker mailContentManager,
      IMailService sendMailService)
   {
      _qryRepo = qryRepo;
      _mailContentManager = mailContentManager;
      _mailService = sendMailService;
   }

   public async Task<OperationResult<Unit>> Handle(TicketCreatedMailNotification request, CancellationToken cancellationToken)
   {
      var result = new OperationResult<Unit>();

      try
      {
         var mailContent = _mailContentManager.TicketCreated(request.Ticket);
         var mailAddressHeaders = await GenerateMailAddressHeadersAsync(
            GetAppropriateSubscriptions(request.Ticket));
         var mailMessages = _mailService.GenerateMailMessages(mailAddressHeaders, mailContent);
         var failedMailMessages = await _mailService
            .SendMailMessagesGetFailedAsync(mailMessages);

         if (failedMailMessages.Any())
         {
            // TO DO: Handle send failures
         }
      }

      catch (Exception e)
      {
         result.AddError(e);
      }

      return result;
   }

   private static IEnumerable<TicketSubscription> GetAppropriateSubscriptions(Ticket ticket)
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
}
