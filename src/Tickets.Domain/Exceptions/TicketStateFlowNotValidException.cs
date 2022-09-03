namespace Tickets.Domain.Exceptions;

public class TicketStateFlowNotValidException : NotValidException
{
   internal TicketStateFlowNotValidException()
   {
   }

   internal TicketStateFlowNotValidException(string message) : base(message)
   {
   }

   internal TicketStateFlowNotValidException(string message, Exception e) : base(message, e)
   {
   }
}
