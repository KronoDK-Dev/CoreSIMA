using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ProcedimientoBE : BaseBE
    {
        public string IdAccion { get; set; }
        public string IdAccionRel { get; set; }
        public string IdAccionTo { get; set; }
        public int IdTipoObj { get; set; }
        public string AccionBasica { get; set; }
        public int Orden { get; set; }
        public string IdActividad { get; set; }
        public string Atributo { get; set; }
    }
}
