using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Categorias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCategoria { get; set; }
        public String Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        //public List<ExpProductos> Productos { get; set; }
        
        public ProductosCategorias ProductosCategoria { get; set; }
        
        public Guid? IdCategoriaPadre { get; set; }
        public Categorias CategoriaPadre { get; set; }
    }
}