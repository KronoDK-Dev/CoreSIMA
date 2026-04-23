using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public  class CCTT_SctrBE : BaseBE
    {
        public string IdSCTR
        {
            get;set;
        }
        public string NroSCTR
        {
            get;set;
        }

        public DateTime FechaInicio
        {
            get;set;
        }

        public DateTime FechaVence
        {
            get;set;
        }

        public int IdTipoSCTR
        {
            get;set;
        }

        public char Modo
        {
            get;set;
        }
        public int IdEntidad
        {
            get; set;
        }
        public int Periodo
        {
            get; set;
        }
        public int NroProg
        {
            get; set;
        }

        public CCTT_SctrBE()
        {
        }
    }
}
