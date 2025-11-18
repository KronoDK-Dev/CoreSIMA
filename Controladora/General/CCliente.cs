using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;

namespace Controladora.General
{
    public class CCliente
    {
        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new ClienteNTAD()).Buscar(TextFind, UserName);
        }
    }
}
