namespace Tickets.Shared.Abstractions.Exceptions;

public abstract class TicketsException : Exception
{
    protected TicketsException(string message) : base(message)
    {
    }
}