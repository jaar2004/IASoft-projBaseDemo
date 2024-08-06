// IAR lun 01JUL2024

using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Domain.Entities;

namespace projBaseDemo.Persistence.Repositories
{
    internal class ArticuloRepository : IArticuloRepository
    {
        private readonly IGenericRepository<Articulo> _repository;

        public ArticuloRepository(IGenericRepository<Articulo> repository)
        {
            _repository = repository;
        }

        // here, put the additional functions for Articulo
         
    }
}
