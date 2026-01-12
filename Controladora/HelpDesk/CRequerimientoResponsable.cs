using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public  class CRequerimientoResponsable
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new RequerimientoResponsableNTAD()).ListarTodos(Id1, UserName);
        }

        public string ModificaInserta(string IdResponsableAprobRqr, string Token, int Aprobado, int IdUsuario, string UserName)
        {
            return (new RequerimientoResponsableTAD()).ModificaInserta(IdResponsableAprobRqr, Token, Aprobado, IdUsuario, UserName);
        }
        public string ModificaInserta(string IdResponsableAprobRqr, string Token, int IdUsuario, string UserName)
        {
            return (new RequerimientoResponsableTAD()).ModificaInserta(IdResponsableAprobRqr, Token,  IdUsuario, UserName);
        }

    }
}
