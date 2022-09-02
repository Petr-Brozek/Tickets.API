using Tickets.Core.Abstractions.Repositories.CmdRepo;

namespace Tickets.Infrastructure.Dal.Repositories.CmdRepos;

public abstract class CommandRepositoryBase<T> : ICommandRepositoryBase<T> where T : class
{
   protected DataContext DataContext { get; set; }

   protected CommandRepositoryBase(DataContext dataContext)
   {
      this.DataContext = dataContext;
   }

   public void Create(T entity) => DataContext.Set<T>().Add(entity);
   public void Update(T entity) => DataContext.Set<T>().Update(entity);
   public void Delete(T entity) => DataContext.Set<T>().Remove(entity);
}
