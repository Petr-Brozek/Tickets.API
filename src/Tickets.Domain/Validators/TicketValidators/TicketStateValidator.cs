using FluentValidation;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators.TicketValidators;

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
