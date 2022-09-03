namespace Tickets.Domain.Abstractions.Repositories.CmdRepo;

public interface ICommandRepositoryBase<T>
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
