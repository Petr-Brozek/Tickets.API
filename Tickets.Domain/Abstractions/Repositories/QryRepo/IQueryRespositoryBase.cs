using System.Linq.Expressions;

namespace Tickets.Domain.Abstractions.Repositories.QryRepo;

public interface IQueryRespositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}
