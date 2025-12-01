using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.Sistemas
{
    public class ActividadComentarioBE : BaseBE
    {
        public string IdDocumento { get; set; }
        public string IdDocPadre { get; set; }
        public string IdActividad { get; set; }
        public int IdTipoDoc { get; set; }
        public string IdPersonal { get; set; }
    }
}
