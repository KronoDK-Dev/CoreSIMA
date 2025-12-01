using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionReportes
{
    public class ObjetoPrivilegioBE : BaseBE
    {
        public int IdPrivilegio { get; set; }
        public int IdObjeto { get; set; }
        public int IdUsuarioCompartido { get; set; }
        public int owner { get; set; }

        public ObjetoPrivilegioBE() { }
    }
}
