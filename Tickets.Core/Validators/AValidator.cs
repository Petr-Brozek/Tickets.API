using FluentValidation;
using Tickets.Core.Exceptions;

namespace Tickets.Core.Validators;

public abstract class AValidator<T> : AbstractValidator<T>
{
 public abstract NotValidException MakeException();
}
