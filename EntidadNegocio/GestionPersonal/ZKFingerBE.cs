using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class ZKFingerBE : BaseBE
    {
        public ZKFingerBE() { }
        public string CodTrabajador { get; set; }
        public string IdHuella { get; set; }
        public string HuellaM1 { get; set; }
        public string HuellaM2 { get; set; }
        public int Version { get; set; }
        public int IdOrg { get; set; }
    }
}
