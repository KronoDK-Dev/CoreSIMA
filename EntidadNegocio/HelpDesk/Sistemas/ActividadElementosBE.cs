using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.Sistemas
{
    public class ActividadElementosBE : BaseBE
    {
        public string IdActElemento { get; set; }
        public string IdActividad { get; set; }
        public string IdActividadElemOrg { get; set; }
        public string Nombre { get; set; }
        public string IdElemento { get; set; }
        public int IdTipoElemento { get; set; }
        public string PathSource { get; set; }

    }
}
