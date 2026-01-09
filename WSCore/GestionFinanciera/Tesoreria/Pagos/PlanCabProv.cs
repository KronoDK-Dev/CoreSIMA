using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class PlanCabProv
    {
        public int iIdPlanCabProv { get; set; }

        public string fFecha { get; set; }

        public string cCodPlanilla { get; set; }

        public string cTipoReg { get; set; }

        public string cCantAboPlan { get; set; }

        public string cFechaProc { get; set; }

        public string cTipoCtaCargo { get; set; }

        public string cMonCtaCargo { get; set; }

        public string cNroCtaCargo { get; set; }

        public string cTotalPlanilla { get; set; }

        public string cPlanillaRef { get; set; }

        public string cFlagExonITF { get; set; }

        public string cTotalControl { get; set; }

        public string cFilter { get; set; }

        public string cNroPlanilla { get; set; }

        public string cNroRegs { get; set; }

        public string cNroRegsRechs { get; set; }

        public string cEstado { get; set; }

        public bool bAprobado { get; set; }

        public string cUsuarioAprobo { get; set; }

        public string fFechaAprobo { get; set; }

        public bool bEnviado { get; set; }

        public string cUsuarioEnvio { get; set; }

        public string fFechaEnvio { get; set; }

        public string cTxtPlanilla { get; set; }

        public string cTipoRpta { get; set; }

        public string cRptaTxtPlanilla { get; set; }

        public IList<PlanDetProv> listPlanDetProv { get; set; }

        public bool bActivo { get; set; }

        public DateTime fFechReg { get; set; }

        public string cUsuReg { get; set; }

        public DateTime fFechAct { get; set; }

        public string cUsuAct { get; set; }
    }

}
