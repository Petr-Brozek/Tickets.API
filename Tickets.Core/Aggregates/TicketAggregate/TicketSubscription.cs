using Tickets.Core.Enums.Ticket;

namespace Tickets.Core.Aggregates.TicketAggregate;

public class TicketSubscription : EntityBaseWithId<Guid>
{
    private TicketSubscription()
    {

    }

    public Guid TicketId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public Guid SubscriberUserProfileId { get; private set; }
    public Guid? CreatedByUserProfileId { get; private set; }
    public TicketSubscriptionDistrType DistrType { get; private set; }
    public TicketSubscriberRole SubscriberRole { get; private set; }
    public bool IsActive { get; private set; }
    public TicketSubscriptionAction OnTicketAction { get; private set; }

    /// <summary>
    /// Creates a new Ticket instance
    /// </summary>
    /// <param name="ticketId"></param>
    /// <param name="subscriberUserProfileId"></param>
    /// <param name="distrType"></param>
    /// <param name="subscriberRole"></param>
    /// <param name="onTicketAction"></param>
    /// <param name="createdByUserProfileId"></param>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public static TicketSubscription CreateTicketSubscription(Guid ticketId, Guid subscriberUserProfileId,
       TicketSubscriptionDistrType distrType, TicketSubscriberRole subscriberRole,
       TicketSubscriptionAction onTicketAction, Guid? createdByUserProfileId = null,
       Ticket? ticket = null)
    {
        var subscriptionToCreate = new TicketSubscription()
        {
            Id = Guid.NewGuid(),
            TicketId = ticketId,
            SubscriberUserProfileId = subscriberUserProfileId,
            DistrType = distrType,
            SubscriberRole = subscriberRole,
            IsActive = true,
            OnTicketAction = onTicketAction,
            CreatedByUserProfileId = createdByUserProfileId,
            Ticket = ticket,
        };

        return subscriptionToCreate;
    }
}
