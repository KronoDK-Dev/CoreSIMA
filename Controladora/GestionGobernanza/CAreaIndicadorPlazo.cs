using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionGobernanza;
using AccesoDatos.Transaccional.GestionGobernanza;

namespace Controladora.GestionGobernanza
{
    public class CAreaIndicadorPlazo
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AreaIndicadorPlazoTAD()).ModificaInserta(oBaseBE);
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new AreaIndicadorPlazoNTAD()).ListarTodos(Id1, Id2, UserName);
        }
    }
}
