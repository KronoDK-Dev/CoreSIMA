using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk.Sistemas;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public class CAprobador
    {
        public DataTable ListarTodos(string Id1, string UserName)
        { 
            return(new AprobadoresNTAD()).ListarTodos(Id1, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AprobadorTAD()).ModificaInserta(oBaseBE);
        }
        public string CambiarEstado(BaseBE oBaseBE)
        {
            return (new AprobadorTAD()).CambiarEstado(oBaseBE);
        }
     }
}
