// IAR lun 01JUL2024
// This interface defines a unit of work pattern that allows us to save changes made by multiple
// repositories at once.

using projBaseDemo.Domain.Common;

namespace projBaseDemo.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();

    }
}
