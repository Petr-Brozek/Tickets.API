namespace Tickets.Domain.Abstractions.Repositories.CmdRepo;

public interface ICommandRepositoryWrapper
{
    ITicketCommandRepository Ticket { get; }
    ITicketCommentCommandRepository TicketComment { get; }
    Task SaveAsync();
}
