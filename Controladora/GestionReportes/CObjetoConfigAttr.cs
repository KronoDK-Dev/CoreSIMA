using AccesoDatos.Transaccional.GestionReportes;
using AccesoDatos.NoTransaccional.GestionReportes;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionReportes
{
    public class CObjetoConfigAttr
    {
        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ObjetoConfigAttrTAD()).ModificarInsertar(oBaseBE);
        }

        public DataTable ListarTodos(string Id1, string Id2, int IdTipoControl, string UserName)
        {
            return (new ObjetoConfigAttrNTAD()).ListarTodos(Id1, Id2, IdTipoControl, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new ObjetoConfigAttrNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }
    }
}
