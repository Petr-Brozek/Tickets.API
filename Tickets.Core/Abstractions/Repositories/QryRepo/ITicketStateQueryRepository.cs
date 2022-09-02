using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Core.Abstractions.Repositories.QryRepo;

public interface ITicketStateQueryRepository : IQueryRespositoryBase<TicketState>
{
    Task<IEnumerable<TicketState>> GetAllTicketStatesAsync();
    Task<TicketState> GetTicketStateByNameAsync(string name);
}
