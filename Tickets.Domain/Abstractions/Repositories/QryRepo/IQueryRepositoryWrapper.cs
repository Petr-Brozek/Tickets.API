namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface IQueryRepositoryWrapper
{
    ITicketQueryRepository Ticket { get; }
    ITicketStateQueryRepository TicketState { get; }
    ITicketCommentQueryRepository TicketComment { get; }
    IUserProfileQueryRepository UserProfile { get; }
}
