using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class StringOperationResult
    {
        public int resultType { get; set; }
        public string message { get; set; }
        public string messageTech { get; set; }
        public object result { get; set; }
        //public string result { get; set; }
        //public List<LecturaError> errores { get; set; }
        // public PlanillaPagos oPlanillaPago { get; set; }
    }
}
