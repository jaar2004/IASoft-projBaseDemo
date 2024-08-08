// IAR mie 07AGO2024

using projBaseDemo.Domain.Common;
using projBaseDemo.Domain.Entities;

namespace projBaseDemo.Application.Features.Articulo.Commands.DeleteArticulo
{
    public class ArticuloDeletedEvent : BaseEvent
    {
        public Domain.Entities.Articulo Articulo { get; }

        public ArticuloDeletedEvent(Domain.Entities.Articulo articulo)
        {
            Articulo = articulo;
        }
    }
}
