using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;

namespace Controladora.GestionCalidad
{
    public class CInspectorInspecciones
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new InspectorInspeccionesNTAD()).ListarTodos(Id1, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new InspectorDetalleTAD()).ModificaInserta(oBaseBE);
        }
    }
}
