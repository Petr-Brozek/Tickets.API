namespace Tickets.Core.Exceptions;

public class TicketCommentNotValidException : NotValidException
{
 internal TicketCommentNotValidException()
 {
 }

 internal TicketCommentNotValidException(string message) : base(message)
 {
 }

 internal TicketCommentNotValidException(string message, Exception e) : base(message, e)
 {
 }
}
