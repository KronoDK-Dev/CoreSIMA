using AccesoDatos.NoTransaccional.HelpDesk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
