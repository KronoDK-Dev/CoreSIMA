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
    public class CPlanTrabajoActividadTareaHistorial
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new PlanTrabajoActividadTareaHistorialNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarTodosParticipantes(string IdHistoria, string UserName)
        {
            return (new PlanTrabajoActividadTareaHistorialNTAD()).ListarTodosParticipantes(IdHistoria, UserName);
        }
        public string Modifica(BaseBE oBaseBE)
        {
            return (new PlanTrabajoActividadTareaHistorialTAD()).Modifica(oBaseBE);
        }
        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new PlanTrabajoActividadTareaHistorialTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
