using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public class TicketQueryRepository : QueryRepositoryBase<Ticket>, ITicketQueryRepository
{
    public TicketQueryRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
       => await FindAll()
          .ToListAsync();

    public async Task<Ticket> GetTicketByIdAsync(Guid ticketId)
       => await FindByCondition(t => t.Id.Equals(ticketId))
          .FirstOrDefaultAsync();

    public async Task<Ticket> GetTicketWithDetailsByIdAsync(Guid ticketId)
       => await FindByCondition(t => t.Id.Equals(ticketId))
          .Include(t => t.CreatedByUserProfile)
          .Include(t => t.State)
          .Include(t => t.Comments)
          .FirstOrDefaultAsync();
}
