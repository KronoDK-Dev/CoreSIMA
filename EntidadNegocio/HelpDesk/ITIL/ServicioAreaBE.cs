using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ServicioAreaBE : BaseBE
    {
        public string IdServicioArea { get; set; }
        public string IdServicioProducto { get; set; }
        public string CodEmp { get; set; }
        public string CodSuc { get; set; }
        public string CodArea { get; set; }
    }
}
