using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ServicioActividadBE : BaseBE
    {
        public string IdServicioProducto { get; set; }
        public string IdActividad { get; set; }
        public int IdEstado { get; set; }
    }
}
