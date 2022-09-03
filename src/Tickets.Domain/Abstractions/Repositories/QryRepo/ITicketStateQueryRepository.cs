using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface ITicketStateQueryRepository : IQueryRespositoryBase<TicketState>
{
    Task<IEnumerable<TicketState>> GetAllTicketStatesAsync();
    Task<TicketState> GetTicketStateByNameAsync(string name);
}
