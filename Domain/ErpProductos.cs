using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ErpProductos
    {
        [Key] public Guid IdProducto { get; set; }
        public decimal Costo { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueCodigo { get; set; } = Guid.NewGuid();

        public DateTime FechaRegistro { get; set; }
        public int Stock { get; set; }
        
        public ExpProductos ExpProductos { get; set; }
    }
}