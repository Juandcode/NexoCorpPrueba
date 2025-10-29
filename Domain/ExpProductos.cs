using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ExpProductos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProducto { get; set; }

        public string Nombre { get; set; } = string.Empty;
        //public decimal Costo { get; set; }
        //public decimal Precio => Costo * (1 + 50 / 100);
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaVencimiento { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public ProductosCategorias ProductosCategoria { get; set; }
        //public List<Categorias> Categorias { get; set; }

        public Guid? IdTipoProducto { get; set; }
        public TiposProductos TiposProductos { get; set; }
        public CodigosBarras CodigosBarras { get; set; }
        
        public ErpProductos ErpProductos { get; set; }
        public VentasExpress VentasExpress { get; set; }
    }
}