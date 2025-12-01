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
    public class CRequerimientoResponsableATencion
    {
        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new RequerimientoResponsableATencionTAD()).Eliminar(Id1, Id2, Id3);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new RequerimientoResponsableATencionTAD()).ModificaInserta(oBaseBE);
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new RequerimientoResponsableAtencionNTAD()).ListarTodos(Id1, UserName);
        }
    }
}
