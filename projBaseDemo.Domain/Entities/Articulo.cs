// IAR mar 21MAY2024

using projBaseDemo.Domain.Common;

namespace projBaseDemo.Domain.Entities
{
    public class Articulo : BaseAuditableEntity
    {
        public int ArticuloId { get; set; }
        public string Itemno { get; set; }
        public string Descripcion { get; set; }

        // IAR jue 30MAY2024
        public  string IdCategoria { get; set; }

        public string Almacen { get; set; }

        public bool Status { get; set; }

        public bool Vigente { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaMod { get; set; }

        public int IdUsuario { get; set; }
        // IAR jue 30MAY2024
    }


    //   [][numeric] (18, 0) IDENTITY(1,1) NOT NULL,
    //   [] [varchar] (20) NOT NULL,
    //   [] [varchar] (80) NOT NULL,
    //   [] [varchar] (3) NOT NULL,
    //   [IdClasePrecio] [varchar] (3) NOT NULL,
    //   [Caja] [int] NULL,
    //[][varchar] (5) NULL,
    //[][tinyint] NULL,
    //[][tinyint] NOT NULL,
    //   [] [smalldatetime] NOT NULL,
    //   [] [smalldatetime] NOT NULL,
    //   [] [int] NOT NULL,
}
