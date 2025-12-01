using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class ResponsableAtencionBE : BaseBE
    {
        public ResponsableAtencionBE() { }

        public string IdResponsable { get; set; }
        public string IdRequerimiento { get; set; }
        public string IdPersonal { get; set; }
    }
}
