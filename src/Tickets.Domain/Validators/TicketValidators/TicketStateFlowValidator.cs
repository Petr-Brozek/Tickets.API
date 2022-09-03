using FluentValidation;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators.TicketValidators;

public class TicketStateFlowValidator : AValidator<TicketStateFlow>
{
   public TicketStateFlowValidator()
   {
      RuleFor(os => os.OriginalStateName)
        .NotNull().WithMessage("Original state name is required");
      RuleFor(os => os.PossibleStateName)
        .NotNull().WithMessage("Possible state name is required");
      RuleFor(os => os.LabelInfinitiveForm)
        .NotNull().WithMessage("Infinitive form label is required")
        .MinimumLength(3).WithMessage("Infinitive form label must be at least 3 characters long");
   }

   public override TicketStateFlowNotValidException MakeException() =>
     new("The ticket state flow is not valid");
}
