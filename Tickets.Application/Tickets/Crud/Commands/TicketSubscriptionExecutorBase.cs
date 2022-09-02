using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Application.Tickets.Commands;
public class TicketSubscriptionBase
{
   public TicketSubscription Subscription;

   public TicketSubscriptionBase(TicketSubscription subscription)
   {
      Subscription = subscription;
   }
}
