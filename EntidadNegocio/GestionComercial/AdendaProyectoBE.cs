using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionComercial
{
    public class AdendaProyectoBE : BaseBE
    {
        public string V_PROYADE_CODPRY { get; set; } // VARCHAR2(11 BYTE)  
        public string N_PROYADE_NROADENDA { get; set; } //NUMBER
        public string N_PROYADE_MONTO { get; set; } // NUMBER(15,5)
        public string V_PROYADE_MONEDA { get; set; } // VARCHAR2(10 BYTE)
        public string D_PROYADE_FECHA { get; set; } // DATE
    }
}
