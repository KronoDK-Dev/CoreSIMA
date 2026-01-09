using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class ActividadAtendidaBE:BaseBE
    {
        public string IdActividad { get; set; }
        public string IdRequerimiento{ get; set; }
        public int  IdPersonalAtiende { get; set; }

    }
}
