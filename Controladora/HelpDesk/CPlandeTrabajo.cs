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
    public class CPlandeTrabajo
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new PlandeTrabajoTAD()).Modifica(oBaseBE);
        }
        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new PlandeTrabajoTAD()).Eliminar(Id1, Id2, Id3);
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return(new PlandeTrabajoNTAD()).ListarTodos(Id1, UserName);
        }
        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            return (new PlandeTrabajoNTAD()).Detalle(Id1, Id2, UserName);
        }
    }
}
