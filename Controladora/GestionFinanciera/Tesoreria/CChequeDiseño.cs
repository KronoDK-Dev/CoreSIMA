using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CChequeDiseño
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ChequeDiseñoNTAD()).ListarTodos(Id1, UserName);
        }
    }
}
