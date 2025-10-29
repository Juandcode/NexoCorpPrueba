using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class TiposProductos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdTipoProducto { get; set; }

        public string Descripcion { get; set; } = string.Empty;
        public ExpProductos ExpProductos { get; set; }
    }
}