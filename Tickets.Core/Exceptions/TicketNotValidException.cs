namespace Tickets.Core.Exceptions;

public class TicketNotValidException : NotValidException
{
 internal TicketNotValidException()
 {
 }

 internal TicketNotValidException(string message) : base(message)
 {
 }

 internal TicketNotValidException(string message, Exception e) : base(message, e)
 {
 }
}
