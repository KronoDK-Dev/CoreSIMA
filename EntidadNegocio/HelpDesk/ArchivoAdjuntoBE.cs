using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class ArchivoAdjuntoBE : BaseBE
    {
        public ArchivoAdjuntoBE() { }
        public string IdFile { get; set; }
        public string IdRequerimiento { get; set; }
        public string Nombre { get; set; }
    }
}
