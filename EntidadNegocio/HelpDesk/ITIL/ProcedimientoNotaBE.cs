using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ProcedimientoNotaBE : BaseBE
    {
        public string IdNota { get; set; }
        public string IdAccion { get; set; }
        public string Titulo { get; set; }
        public int IdTipoNota { get; set; }
        public string TipoNota { get; set; }
    }
}
