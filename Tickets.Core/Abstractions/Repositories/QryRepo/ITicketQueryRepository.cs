using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Core.Abstractions.Repositories.QryRepo;

public interface ITicketQueryRepository : IQueryRespositoryBase<Ticket>
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(Guid ticketId);
    Task<Ticket> GetTicketWithDetailsByIdAsync(Guid ticketId);
}
