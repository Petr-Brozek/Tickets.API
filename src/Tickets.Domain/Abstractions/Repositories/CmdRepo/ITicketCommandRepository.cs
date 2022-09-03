using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Domain.Abstractions.Repositories.CmdRepo;

public interface ITicketCommandRepository : ICommandRepositoryBase<Ticket>
{
    void CreateTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(Ticket ticket);
}
