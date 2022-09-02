using Tickets.Core.Aggregates.UserProfileAggregate;
using Tickets.Core.Enums.Ticket;
using Tickets.Core.Exceptions;
using Tickets.Core.Validators;
using Tickets.Core.Validators.TicketValidators;

namespace Tickets.Core.Aggregates.TicketAggregate;

public class Ticket : EntityBaseWithId<Guid>
{
    private Ticket()
    {

    }

    public string Summary { get; private set; } = string.Empty;
    public TicketStateName StateName { get; private set; }
    public TicketState? State { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime LastModifiedDate { get; private set; }

    public Guid CreatedByUserProfileId { get; private set; }
    public UserProfile? CreatedByUserProfile { get; private set; }

    private List<TicketComment> _comments = new();
    public IReadOnlyList<TicketComment> Comments => _comments.AsReadOnly();

    private List<TicketSubscription> _subscriptions = new();
    public IReadOnlyCollection<TicketSubscription> Subscriptions => _subscriptions.AsReadOnly();

    /// <summary>
    /// Creates a new Ticket instance
    /// </summary>
    /// <param name="summary"></param>
    /// <param name="createdByUserProfileId"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    /// <exception cref="TicketNotValidException"></exception>
    public static Ticket CreateTicket(string summary, Guid createdByUserProfileId)
    {
        var ticketToCreate = new Ticket()
        {
            Id = Guid.NewGuid(),
            Summary = summary,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            CreatedByUserProfileId = createdByUserProfileId,
            StateName = TicketStateName.New,
        };

        return ValidateTicket(ticketToCreate);
    }

    public Ticket UpdateTicketSummary(string newSummary)
    {
        Summary = newSummary;
        LastModifiedDate = DateTime.Now;

        return ValidateTicket(this);
    }

    public Ticket UpdateTicketState(TicketState newState)
    {
        State = newState;
        LastModifiedDate = DateTime.Now;

        return this;
    }

    public Ticket UpdateCreator(UserProfile newCreator)
    {
        CreatedByUserProfileId = newCreator.UserProfileId;
        CreatedByUserProfile = newCreator;

        return this;
    }

    public Ticket AddComment(TicketComment comment)
    {
        _comments.Add(comment);
        return this;
    }

    public Ticket AddSubscription(TicketSubscription subscription)
    {
        _subscriptions.Add(subscription);

        return this;
    }

    public Ticket AddSubscriptions(ICollection<TicketSubscription> subscriptions)
    {
        _subscriptions.AddRange(subscriptions);

        return this;
    }

    private static Ticket ValidateTicket(Ticket ticketToValidate)
    {
        var validator = new Validator<Ticket>(new TicketValidator());

        return validator.Validate(ticketToValidate);
    }
}
