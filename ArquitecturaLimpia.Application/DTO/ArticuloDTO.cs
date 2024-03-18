using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaLimpia.Domain.DTO
{
    public class ArticuloDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Stock { get; set; }
        public int CategoriaId { get; set; }
    }
}
