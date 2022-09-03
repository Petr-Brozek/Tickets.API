namespace Tickets.Domain.Exceptions;

public class NotValidException : Exception
{
 internal NotValidException()
 {
 }

 internal NotValidException(string message) : base(message)
 {
 }

 internal NotValidException(string message, Exception e) : base(message, e)
 {
 }

 internal List<string> ValidationErrors { get; } = new List<string>();
}
