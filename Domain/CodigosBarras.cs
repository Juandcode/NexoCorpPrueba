using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class CodigosBarras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCodigoBarra { get; set; }
        
        public Guid UniqueCodigo { get; set; } = Guid.NewGuid();

        public bool Activo { get; set; } = true;
        
        public Guid? IdProducto { get; set; }
        public ExpProductos ExpProductos { get; set; }
    }
}