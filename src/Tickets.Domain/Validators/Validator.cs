namespace Tickets.Domain.Validators;

public class Validator<T>
{
 private readonly AValidator<T> _validator;

 public Validator(AValidator<T> validator)
 {
   _validator = validator;
 }

 public T Validate(T value)
 {
   var validationResult = _validator.Validate(value);

   if (validationResult.IsValid)
     return value;

   var exception = _validator.MakeException();
   foreach (var error in validationResult.Errors)
     exception.ValidationErrors.Add(error.ErrorMessage);

   throw exception;
 }
}
