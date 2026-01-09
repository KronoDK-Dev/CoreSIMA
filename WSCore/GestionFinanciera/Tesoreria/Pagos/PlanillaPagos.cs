using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public class PlanillaPagos
    {
        public PlanCabProv datos { get; set; }

        public Archivo archivo { get; set; }

        public List<LecturaError> error { get; set; }
    }
}
