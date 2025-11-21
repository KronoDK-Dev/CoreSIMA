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
    public class CAccionResponsable
    {
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new AccionResponsableNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new AccionResponsableNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AccionResponsableTAD()).ModificaInserta(oBaseBE);
        }
    }
}
