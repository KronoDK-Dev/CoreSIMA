using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;

namespace Controladora.HelpDesk
{
    public class CPlanTrabajoActividad
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new PlanTrabajoActividadNTAD()).ListarTodos(Id1, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new PlanTrabajoActividadTAD()).ModificaInserta(oBaseBE);
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new PlanTrabajoActividadTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
