using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionReportes;
using AccesoDatos.Transaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CObjetoMapeoExport
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ObjetoMapeoExportNTAD()).ListarTodos(Id1, UserName);
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ObjetoMapeoExportTAD()).ModificarInsertar(oBaseBE);
        }
    }
}
