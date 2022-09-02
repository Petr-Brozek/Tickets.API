namespace Tickets.Core.Aggregates.TicketAggregate;
public abstract class EntityBaseWithId<T> : EntityBase
{
    public T Id { get; set; }
}
