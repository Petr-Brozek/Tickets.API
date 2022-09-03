using Tickets.Domain.Enums.Ticket;
using Tickets.Domain.Exceptions;
using Tickets.Domain.Validators;
using Tickets.Domain.Validators.TicketValidators;

namespace Tickets.Domain.Aggregates.TicketAggregate;

public class TicketState : EntityBase
{
    private TicketState()
    {

    }

    public TicketStateName Name { get; private set; }
    public string Label { get; private set; } = string.Empty;

    /// <summary>
    /// Creates a new TicketState instance
    /// </summary>
    /// <param name="name"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    /// <exception cref="TicketStateNotValidException"></exception>
    public static TicketState CreateTicketState(TicketStateName name, string label)
    {
        var ticketStateToCreate = new TicketState()
        {
            Name = name,
            Label = label,
        };

        return ValidateTicketState(ticketStateToCreate);
    }

    /// <summary>
    /// Creates a default TicketState instance for a new Ticket
    /// </summary>
    /// <returns></returns>
    /// <exception cref="TicketStateNotValidException"></exception>
    public static TicketState CreateNewTicketDefaultState()
    {
        var ticketStateToCreate = new TicketState()
        {
            Name = TicketStateName.New,
            Label = "New",
        };

        return ValidateTicketState(ticketStateToCreate);
    }

    private static TicketState ValidateTicketState(TicketState ticketStateToValidate)
    {
        var validator = new Validator<TicketState>(new TicketStateValidator());

        return validator.Validate(ticketStateToValidate);
    }
}
