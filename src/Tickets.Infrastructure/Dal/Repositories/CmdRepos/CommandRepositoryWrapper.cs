using Tickets.Domain.Abstractions.Repositories.CmdRepo;

namespace Tickets.Infrastructure.Dal.Repositories.CmdRepos;

public class CommandRepositoryWrapper : ICommandRepositoryWrapper
{
   private readonly DataContext _repoContext;
   private ITicketCommandRepository _ticket;
   private ITicketCommentCommandRepository _ticketComment;

   public ITicketCommandRepository Ticket
   {
      get
      {
         _ticket ??= new TicketCommandRepository(_repoContext);
         return _ticket;
      }
   }

   public ITicketCommentCommandRepository TicketComment
   {
      get
      {
         _ticketComment ??= new TicketCommentCommandRepository(_repoContext);
         return _ticketComment;
      }
   }

   public CommandRepositoryWrapper(DataContext repoContext)
   {
      _repoContext = repoContext;
   }

   public async Task SaveAsync()
   {
      await _repoContext.SaveChangesAsync();
   }
}
