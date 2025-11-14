using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class PlanDetProv
    {
        public int iIdPlanDetProv { get; set; }

        public int iIdPlanCabProv { get; set; }

        public string cTipoReg { get; set; }

        public string cTipoCtaAbono { get; set; }

        public string cNroCtaAbono { get; set; }

        public string cModPago { get; set; }

        public string cTipoDocProv { get; set; }

        public string cNroDocProv { get; set; }

        public string cCorrelaDocProv { get; set; }

        public string cNombProv { get; set; }

        public string cRefBenef { get; set; }

        public string cRefEmpresa { get; set; }

        public string cMonImpAbonar { get; set; }

        public string cImpAbonar { get; set; }

        public string cFlagValIDC { get; set; }

        public string cFilter { get; set; }

        public string cTipoCambio { get; set; }

        public string cMontoAbono { get; set; }

        public string cEstado { get; set; }

        public string cObserva { get; set; }

        public DetDocBenef detDocBenef { get; set; }

        public bool bActivo { get; set; }

        public DateTime fFechReg { get; set; }

        public string cUsuReg { get; set; }

        public DateTime fFechAct { get; set; }

        public string cUsuAct { get; set; }
    }
}
