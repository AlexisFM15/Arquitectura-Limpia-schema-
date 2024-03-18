    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaLimpia.Domain.DTO
{
    public class CategoriaDTO : EntityBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
