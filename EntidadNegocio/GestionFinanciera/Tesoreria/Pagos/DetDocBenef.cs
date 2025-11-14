using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class DetDocBenef
    {
        public DetDocBenef()
        {
            this.cTipoReg = "";
            this.cTipoDocPagar = "";
            this.cNroDocPagar = "";
            this.cImpDocPagar = "";
        }

        public int iIdDetDocBenef { get; set; }

        public int iIdPlanDetProv { get; set; }

        public string cTipoReg { get; set; }

        public string cTipoDocPagar { get; set; }

        public string cNroDocPagar { get; set; }

        public string cImpDocPagar { get; set; }

        public bool bActivo { get; set; }

        public DateTime fFechReg { get; set; }

        public string cUsuReg { get; set; }

        public DateTime fFechAct { get; set; }

        public string cUsuAct { get; set; }
    }
}
