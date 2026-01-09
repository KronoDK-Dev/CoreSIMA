using AccesoDatos.NoTransaccional.GestionGobernanza;
using AccesoDatos.Transaccional.GestionGobernanza;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionGobernanza
{
    public class CAccionIndicador
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new IndicadorTAD()).ModificaInserta(oBaseBE);
        }
        public string Eliminar(BaseBE oBaseBE) {
            return (new IndicadorTAD()).Eliminar(oBaseBE);
        }
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new AccionIndicadorNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public DataTable ListarIndicadoresPorArea(string CodArea, string UserName)
        {
            return (new AccionIndicadorNTAD()).ListarIndicadoresPorArea(CodArea, UserName);
        }
     }
}
