// IAR jue 08AGO2024

using projBaseDemo.Application.Common.Mappings;

namespace projBaseDemo.Application.Features.Articulo.Queries.GetArticulosWithPagination
{
    public  class GetArticulosWithPaginationDto : IMapFrom<Domain.Entities.Articulo>
    {
        public int ArticuloId { get; set; }
        public string Itemno { get; set; }
        public string Descripcion { get; set; }
        public string IdCategoria { get; set; }
        public string Almacen { get; set; }
        public bool Status { get; set; }
        public bool Vigente { get; set; }
        public int IdUsuario { get; set; }
    }
}
