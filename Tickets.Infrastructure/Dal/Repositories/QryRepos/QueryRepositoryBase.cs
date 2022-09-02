using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tickets.Core.Abstractions.Repositories.QryRepo;

namespace Tickets.Infrastructure.Dal.Repositories.QryRepos;

public abstract class QueryRepositoryBase<T> : IQueryRespositoryBase<T> where T : class
{
   protected DataContext DataContext { get; set; }

   protected QueryRepositoryBase(DataContext dataContext)
   {
      DataContext = dataContext;
   }

   public IQueryable<T> FindAll() => DataContext.Set<T>().AsNoTracking();

   public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
      => DataContext.Set<T>().Where(expression).AsNoTracking();
}
