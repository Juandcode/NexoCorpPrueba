using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class VentasExpress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public Guid UniqueProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; } = 0;
        public decimal Total { get; set; }
        
        public Guid IdProducto { get; set; }
        public ExpProductos ExpProductos { get; set; }
    }
}