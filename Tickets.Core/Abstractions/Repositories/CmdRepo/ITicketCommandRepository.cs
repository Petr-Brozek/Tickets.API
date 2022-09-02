using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Core.Abstractions.Repositories.CmdRepo;

public interface ITicketCommandRepository : ICommandRepositoryBase<Ticket>
{
    void CreateTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(Ticket ticket);
}
