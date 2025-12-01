using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.Sistemas
{
    public class SistemaProcesoSubProcesoBE : BaseBE
    {
        public string IdSys { get; set; }
        public string IdPadre { get; set; }
        public string Nombre { get; set; }
        public int IdNivel { get; set; }
    }
}
