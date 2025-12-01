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
    public class CRequerimientoResponsableEstado
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new RequerimientoResponsableEstadoNTAD()).ListarTodos(Id1, UserName);
        }

        public string ModificaInserta(string IdResponsable, string Descripcion, int IdEstado, string UserName)
        {
            return (new RequerimientoResponsableEstadoTAD()).ModificaInserta(IdResponsable, Descripcion, IdEstado, UserName);
        }
    }
}
