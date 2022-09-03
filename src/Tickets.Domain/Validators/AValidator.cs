using FluentValidation;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Validators;

public abstract class AValidator<T> : AbstractValidator<T>
{
 public abstract NotValidException MakeException();
}
