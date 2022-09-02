using FluentValidation;
using Tickets.Core.Aggregates.TicketAggregate;
using Tickets.Core.Exceptions;

namespace Tickets.Core.Validators.TicketValidators;

public class TicketStateValidator : AValidator<TicketState>
{
 public TicketStateValidator()
 {
   RuleFor(ts => ts.Name)
     .NotNull().WithMessage("State name is required");
 }

 public override TicketStateNotValidException MakeException() =>
   new("The ticket state is not valid");
}
