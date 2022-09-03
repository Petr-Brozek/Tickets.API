using Tickets.Domain.Enums.Ticket;

namespace Tickets.Presentation.Contracts.Tickets.Requests;

public record TicketSubscriptionToCreate
{
   public Guid SubscriberUserProfileId { get; set; }
   public Guid? CreatedByUserProfileId { get; set; }
   public TicketSubscriptionDistrType DistrType { get; set; }
   public TicketSubscriberRole SubscriberRole { get; set; }
   public TicketSubscriptionAction OnTicketAction { get; set; }
}
