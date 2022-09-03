using FluentValidation;
using Tickets.Domain.Aggregates.TicketAggregate;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators.TicketValidators;

public class TicketCommentValidator : AValidator<TicketComment>
{
 public TicketCommentValidator()
 {
   RuleFor(bi => bi.Content)
     .NotNull().WithMessage("Content is required")
     .MaximumLength(2000).WithMessage("Content must be at last 2000 characters long");
 }

 public override TicketCommentNotValidException MakeException() =>
   new("The ticket comment is not valid");
}
