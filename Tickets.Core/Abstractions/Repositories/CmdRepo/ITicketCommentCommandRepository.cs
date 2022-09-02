using Tickets.Core.Aggregates.TicketAggregate;

namespace Tickets.Core.Abstractions.Repositories.CmdRepo;

public interface ITicketCommentCommandRepository : ICommandRepositoryBase<TicketComment>
{
    void CreateTicketComment(TicketComment ticketComamnd);
    void UpdateTicketComment(TicketComment ticketComment);
    void DeleteTicketComment(TicketComment ticketComment);
}
