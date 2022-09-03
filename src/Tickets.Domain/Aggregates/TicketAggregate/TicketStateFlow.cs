using Tickets.Domain.Enums.Ticket;
using Tickets.Domain.Exceptions;
using Tickets.Domain.Validators;
using Tickets.Domain.Validators.TicketValidators;

namespace Tickets.Domain.Aggregates.TicketAggregate;

public class TicketStateFlow : EntityBase
{

    private TicketStateFlow()
    {

    }

    public TicketStateName OriginalStateName { get; private set; }
    public TicketStateName PossibleStateName { get; private set; }
    public TicketState OriginalState { get; private set; }
    public TicketState PossibleState { get; private set; }
    public string LabelInfinitiveForm { get; private set; } = string.Empty;


    /// <summary>
    /// Creates new TicketStateFlow instance
    /// </summary>
    /// <param name="originalStateName"></param>
    /// <param name="possibleStateName"></param>
    /// <param name="labelInfinitiveForm"></param>
    /// <returns></returns>
    /// <exception cref="TicketStateFlowNotValidException"></exception>
    public static TicketStateFlow CreateTicketStateFlow(TicketStateName originalStateName,
       TicketStateName possibleStateName, string labelInfinitiveForm)
    {
        var ticketStateFlowToCreate = new TicketStateFlow()
        {
            OriginalStateName = originalStateName,
            PossibleStateName = possibleStateName,
            LabelInfinitiveForm = labelInfinitiveForm
        };

        return ValidateTicketStateFlow(ticketStateFlowToCreate);
    }

    private static TicketStateFlow ValidateTicketStateFlow(TicketStateFlow ticketStateFloeToValidate)
    {
        var validator = new Validator<TicketStateFlow>(new TicketStateFlowValidator());

        return validator.Validate(ticketStateFloeToValidate);
    }
}
