using Tickets.Core.Abstractions.Repositories.QryRepo;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public class QueryRepositoryWrapper : IQueryRepositoryWrapper
{
   private readonly DataContext _repoContext;
   private ITicketQueryRepository _ticket;
   private ITicketStateQueryRepository _ticketState;
   private ITicketCommentQueryRepository _ticketComment;
   private IUserProfileQueryRepository _userProfile;

   public ITicketQueryRepository Ticket
   {
      get
      {
         _ticket ??= new TicketQueryRepository(_repoContext);
         return _ticket;
      }
   }

   public ITicketStateQueryRepository TicketState
   {
      get
      {
         _ticketState ??= new TicketStateQueryRepository(_repoContext);
         return _ticketState;
      }
   }

   public ITicketCommentQueryRepository TicketComment
   {
      get
      {
         _ticketComment ??= new TicketCommentQueryRepository(_repoContext);
         return _ticketComment;
      }
   }

   public IUserProfileQueryRepository UserProfile
   {
      get
      {
         _userProfile ??= new UserProfileQueryRepository(_repoContext);
         return _userProfile;
      }
   }

   public QueryRepositoryWrapper(DataContext repositoryContext)
      => _repoContext = repositoryContext;
}
