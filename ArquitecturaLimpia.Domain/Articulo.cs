using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaLimpia.Domain
{
    public class Articulo : EntityBase
    {
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(300)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }
        public double Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get;  set; }
    }
}
