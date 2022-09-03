using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface ITicketQueryRepository : IQueryRespositoryBase<Ticket>
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(Guid ticketId);
    Task<Ticket> GetTicketWithDetailsByIdAsync(Guid ticketId);
}
