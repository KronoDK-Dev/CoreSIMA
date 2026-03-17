using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public  class CCTT_Programacion_CtrlEquiposBE:BaseBE
    {
        public int NroProgramacion
        {
            get;
            set;
        }
        public int Periodo
        {
            get;
            set;
        }

        public int NroItem
        {
            get;
            set;
        }

        public string Codigo
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }

        public int IdTipoInOut
        {
            get;
            set;
        }

        public int NroProgramacionRel
        {
            get;
            set;
        }

        public int PeriodoRel
        {
            get;
            set;
        }

    }
}
