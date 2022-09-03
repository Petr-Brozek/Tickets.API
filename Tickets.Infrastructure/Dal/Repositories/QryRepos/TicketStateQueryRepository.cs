using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Abstractions.Repositories.QryRepo;
using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public class TicketStateQueryRepository : QueryRepositoryBase<TicketState>, ITicketStateQueryRepository
{
    public TicketStateQueryRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<TicketState>> GetAllTicketStatesAsync()
    => await FindAll()
       .ToListAsync();

    public async Task<TicketState> GetTicketStateByNameAsync(string name)
    => await FindByCondition(ts => ts.Name.Equals(name))
       .FirstOrDefaultAsync();
}
