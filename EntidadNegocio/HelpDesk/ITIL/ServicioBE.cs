using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ServicioBE : BaseBE
    {
        public string IdServicioProducto { get; set; }
        public string IdPadre { get; set; }
        public string Nombre { get; set; }
        public int Interno { get; set; }
        public int Producto { get; set; }
    }
}
