using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public  class AutorizaIngFeriadoBE:BaseBE
    {
        public string NroDNI
        {
            get;
            set;
        }
        public DateTime FechaAutorizada
        {
            get;
            set;
        }

        public int IdPersonalAutoriza
        {
            get;
            set;
        }


    }
}
