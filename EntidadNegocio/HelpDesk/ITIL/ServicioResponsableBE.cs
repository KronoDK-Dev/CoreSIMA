using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk.ITIL
{
    public class ServicioResponsableBE : BaseBE
    {
        public string pID_RESPONSABLE { get; set; }
        public string pID_SERV_AREA { get; set; }
        public int pID_PERSONAL { get; set; }
        public int pPRINCIPAL { get; set; }
    }
}
