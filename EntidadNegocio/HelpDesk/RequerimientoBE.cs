using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class RequerimientoBE:BaseBE
    {
        public RequerimientoBE() { }
        public string IdRequerimiento { get; set; }
        public string IdRequerientoPadre { get; set; }
        public string IdServicioArea { get; set; }
        public string PathServicio { get; set; }

        public string NroTicket { get; set; }
        public string IdPersonal { get; set; }

        public int IdPrioridadSolicitada { get; set; }
        public int IdPrioridadAtendida{ get; set; }
        

    }
}
