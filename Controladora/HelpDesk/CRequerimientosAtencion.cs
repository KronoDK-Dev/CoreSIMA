using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk;

namespace Controladora.HelpDesk
{
    public class CRequerimientosAtencion
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new RequerimientosAtencionNTAD()).ListarTodos(Id1, UserName);
        }
    }
}
