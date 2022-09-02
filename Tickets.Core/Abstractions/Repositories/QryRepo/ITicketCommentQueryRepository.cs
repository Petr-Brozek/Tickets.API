using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Core.Abstractions.Repositories.QryRepo;

public interface ITicketCommentQueryRepository : IQueryRespositoryBase<TicketComment>
{
    Task<TicketComment> GetTicketCommentByIdAsync(Guid commentId);
}
