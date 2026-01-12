using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public  class CPlanTrabajoTareas
    {
        public DataTable ListarTodos(string Id1, string Id2 , string UserName)
        {
            return (new PlanTrabajoTareasNTAD()).ListarTodos(Id1, Id2, UserName);
        }
        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            return (new PlanTrabajoTareasNTAD()).Detalle(Id1, Id2, UserName);
        }
      
    }
}
