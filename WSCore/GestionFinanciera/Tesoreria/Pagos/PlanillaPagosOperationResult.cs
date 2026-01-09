using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class PlanillaPagosOperationResult
    {
        public int resultType { get; set; }

        public string message { get; set; }

        public string messageTech { get; set; }

        public PlanillaPagos result { get; set; }
    }

}
