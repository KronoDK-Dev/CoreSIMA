using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class StringOperationResult
    {
        public int resultType { get; set; }

        public string message { get; set; }

        public string messageTech { get; set; }

        public object result { get; set; }
    }
}
