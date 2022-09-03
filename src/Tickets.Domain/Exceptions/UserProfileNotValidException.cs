namespace Tickets.Domain.Exceptions;

public class UserProfileNotValidException : NotValidException
{
 internal UserProfileNotValidException()
 {
 }

 internal UserProfileNotValidException(string message) : base(message)
 {
 }

 internal UserProfileNotValidException(string message, Exception e) : base(message, e)
 {
 }
}
