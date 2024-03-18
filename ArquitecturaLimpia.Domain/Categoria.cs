using System.ComponentModel.DataAnnotations;

namespace ArquitecturaLimpia.Domain
{
    public class Categoria : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(300)]
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
