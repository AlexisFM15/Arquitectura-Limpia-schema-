using ArquitecturaLimpia.Domain;
using System.Linq.Expressions;

namespace ArquitecturaLimpia.Application.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetById(int id);
        Task<IEnumerable<T>> List();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task Delete(int idEntity);
        Task Update(T entity);
    }
}
