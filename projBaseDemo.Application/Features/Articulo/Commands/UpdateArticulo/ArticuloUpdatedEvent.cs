// IAR mie 07AGO2024

using projBaseDemo.Domain.Common;

namespace projBaseDemo.Application.Features.Articulo.Commands.UpdateArticulo
{
    public class ArticuloUpdatedEvent : BaseEvent
    {
        public Domain.Entities.Articulo Articulo { get; }

        public ArticuloUpdatedEvent(Domain.Entities.Articulo articulo)
        {
            Articulo = articulo;
        }
    }
}
