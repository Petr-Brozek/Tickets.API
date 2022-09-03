using FluentValidation;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators.TicketValidators;

public class TicketValidator : AValidator<Ticket>
{
 public TicketValidator()
 {
   RuleFor(bi => bi.Summary)
     .NotNull().WithMessage("Summary is required")
     .MinimumLength(3).WithMessage("Summary must be at least 3 characters long")
     .MaximumLength(200).WithMessage("Summary must be at last 200 characters long");
 }

 public override TicketNotValidException MakeException() =>
   new("The ticket is not valid");
}
