// IAR mie 07AGO2024

using projBaseDemo.Domain.Common;
using projBaseDemo.Domain.Entities;

/*
IAR mie 07AGO2024
Solución a problema de namespace.
Tenia error con el namespace "projBaseDemo.Domain.Entities" no lo estaba detectando.
Usé en su lugar "Domain.Entities.Articulo" directamente en la línea de código.

Texto búsqueda: is a namespace but is using like a type
It happens when the namespace and class name are the same. do one thing write the full name of the 
namespace when you want to use the namespace.

*/

namespace projBaseDemo.Application.Features.Articulo.Commands.CreateArticulo
{
    public class ArticuloCreatedEvent : BaseEvent
    {
        public Domain.Entities.Articulo Articulo { get; }

        public ArticuloCreatedEvent(Domain.Entities.Articulo articulo)
        {
            Articulo = articulo;
        }

    }
}
