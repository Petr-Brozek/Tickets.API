using FluentValidation;
using Tickets.Domain.Aggregates.UserProfileAggregate;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators.UserProfileValidators;

public class BasicInfoValidator : AValidator<BasicInfo>
{
 public BasicInfoValidator()
 {
   RuleFor(bi => bi.FirstName)
     .NotNull().WithMessage("Firtname is required")
     .MinimumLength(3).WithMessage("Firstname must be at least 3 characters long")
     .MaximumLength(50).WithMessage("Firstname must be at last 50 characters long");

   RuleFor(bi => bi.LastName)
     .NotNull().WithMessage("Lastname is required")
     .MinimumLength(3).WithMessage("Lastname must be at least 3 characters long")
     .MaximumLength(50).WithMessage("Lastname must be at last 50 characters long");

   RuleFor(bi => bi.EmailAddress)
       .NotNull().WithMessage("Email address is required")
       .EmailAddress().WithMessage("Wrong format of email address");
 }

 public override UserProfileNotValidException MakeException() =>
   new("The Userprofile is not valid");
}
