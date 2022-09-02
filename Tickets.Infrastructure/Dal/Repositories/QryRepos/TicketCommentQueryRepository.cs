using Microsoft.EntityFrameworkCore;
using Tickets.Core.Abstractions.Repositories.QryRepo;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public class TicketCommentQueryRepository : QueryRepositoryBase<TicketComment>, ITicketCommentQueryRepository
{
    public TicketCommentQueryRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<TicketComment> GetTicketCommentByIdAsync(Guid commentId)
    => await FindByCondition(tc => tc.Id.Equals(commentId))
       .FirstOrDefaultAsync();
}
