namespace Tickets.Core.Exceptions;

public class TicketStateNotValidException : NotValidException
{
   internal TicketStateNotValidException()
   {
   }

   internal TicketStateNotValidException(string message) : base(message)
   {
   }

   internal TicketStateNotValidException(string message, Exception e) : base(message, e)
   {
   }
}
