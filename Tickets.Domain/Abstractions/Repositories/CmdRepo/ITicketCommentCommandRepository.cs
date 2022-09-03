using Tickets.Domain.Aggregates.TicketAggregate;

namespace Tickets.Domain.Abstractions.Repositories.CmdRepo;

public interface ITicketCommentCommandRepository : ICommandRepositoryBase<TicketComment>
{
    void CreateTicketComment(TicketComment ticketComamnd);
    void UpdateTicketComment(TicketComment ticketComment);
    void DeleteTicketComment(TicketComment ticketComment);
}
