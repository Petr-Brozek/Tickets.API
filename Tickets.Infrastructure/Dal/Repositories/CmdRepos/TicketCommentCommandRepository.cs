using Tickets.Core.Abstractions.Repositories.CmdRepo;
using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Infrastructure.Dal.Repositories.CmdRepos;

public class TicketCommentCommandRepository : CommandRepositoryBase<TicketComment>, ITicketCommentCommandRepository
{
    public TicketCommentCommandRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public void CreateTicketComment(TicketComment ticketComment)
    {
        Create(ticketComment);
    }

    public void DeleteTicketComment(TicketComment ticketComment)
    {
        Delete(ticketComment);
    }

    public void UpdateTicketComment(TicketComment ticketComment)
    {
        Update(ticketComment);
    }
}
