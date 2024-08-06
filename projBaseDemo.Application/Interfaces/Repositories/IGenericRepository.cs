// IAR lun 01JUL2024
// This interface defines a generic repository and it contains generic CRUD methods.

// Patrón de diseño repositorio genérico.

using projBaseDemo.Domain.Common.Interfaces;

namespace projBaseDemo.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        // Esta nomenclatura "where T : class, IEntity" indica que la interface va a recibir un objeto T
        // donde T es de la clase IEntity. IAR dom 07MAY2023
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
