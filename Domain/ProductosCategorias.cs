using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ProductosCategorias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdDetalle { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public Guid? IdProducto { get; set; }
        public ExpProductos ExpProductos { get; set; }

        public Guid? IdCategoria { get; set; }
        public Categorias Categorias { get; set; }
    }
}