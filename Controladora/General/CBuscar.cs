using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;

namespace Controladora.General
{
    public class CBuscar
    {
        public DataTable BuscarPersonal(string TextFind, string UserName)
        {
            return (new BuscarNTAD()).BuscarPersonal(TextFind, UserName);
        }

        public DataTable BuscarArea(string TextFind, string UserName)
        {
            return (new BuscarNTAD()).BuscarArea(TextFind, UserName);
        }
    }
}
