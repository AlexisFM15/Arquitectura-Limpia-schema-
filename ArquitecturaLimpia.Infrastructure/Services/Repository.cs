using ArquitecturaLimpia.Application.Interface;
using ArquitecturaLimpia.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArquitecturaLimpia.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _dbContext;
        private AppDbContext context;
        protected readonly DbSet<T> _dbSet;

        public IUnitOfWork UnitOfWork
        { get 
            {
                return (IUnitOfWork)_dbContext;
            }
        }

        public Repository()
        {
            _dbContext = new AppDbContext();
            _dbSet = _dbContext.Set<T>();
            
        }
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
             _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int idEntity)
        {
            var entity = _dbSet.Find(idEntity);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

    }   
}
