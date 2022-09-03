using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface ITicketCommentQueryRepository : IQueryRespositoryBase<TicketComment>
{
    Task<TicketComment> GetTicketCommentByIdAsync(Guid commentId);
}
