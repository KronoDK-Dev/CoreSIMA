using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public  class CCTT_SctrDetalleBE:BaseBE
    {
        public string IdDetalleSCTR
        {
            get; set;
        }
        public string IdSCTR
        {
            get; set;
        }

        public string NroDNI
        {
            get; set;
        }

        public DateTime tFechaInicio
        {
            get; set;
        }

        public DateTime tFechaVence
        {
            get; set;
        }

        public string Observacion
        {
            get; set;
        }

        public string Modo
        {
            get; set;
        }


    }
}
