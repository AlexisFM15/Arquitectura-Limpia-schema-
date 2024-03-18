using Microsoft.EntityFrameworkCore.Storage;

namespace ArquitecturaLimpia.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        bool HasActiveTransaction { get; }
        IDbContextTransaction GetCurrentTransaction1();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync(IDbContextTransaction transaction);
    }
}
