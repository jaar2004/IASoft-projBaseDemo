// IAR lun 01JUL2024

// Most of the time, repositories will only use the generic methods defined in the IGenericRepository
// class but if they have some additional functionality and require a custom method implementation
// then these methods can be defined in specific repository interfaces. In the following example,
// IPlayerRepository is defining an additional method to get players by the club.
/*
   La mayoría de las veces, los repositorios solamente usarán métodos genéricos definidos en la clase
   IGenericRepository pero si tiene algunas funcionalidades adicionales y requiere una implementación
   de métodos personalizados entonces estos métodos pueden ser definidos en una interfase de repositorio
   específica. En esta clase, se define un método adicional para obtener jugadores por el club
*/

using projBaseDemo.Domain.Entities;

namespace projBaseDemo.Application.Interfaces.Repositories
{
    public interface IArticuloRepository
    {
        Task<List<Articulo>> GetArticulosAsync();

    }
}
