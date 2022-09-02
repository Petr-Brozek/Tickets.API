using System.Linq.Expressions;

namespace Tickets.Core.Abstractions.Repositories.QryRepo;

public interface IQueryRespositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}
