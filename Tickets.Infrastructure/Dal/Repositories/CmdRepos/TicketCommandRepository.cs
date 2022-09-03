using Tickets.Domain.Abstractions.Repositories.CmdRepo;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.CmdRepos;

public class TicketCommandRepository : CommandRepositoryBase<Ticket>, ITicketCommandRepository
{
    public TicketCommandRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public void CreateTicket(Ticket ticket)
    {
        Create(ticket);
    }

    public void DeleteTicket(Ticket ticket)
    {
        Delete(ticket);
    }

    public void UpdateTicket(Ticket ticket)
    {
        Update(ticket);
    }
}
