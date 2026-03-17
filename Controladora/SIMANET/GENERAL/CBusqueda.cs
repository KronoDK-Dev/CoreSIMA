using AccesoDatos;
using AccesoDatos.NoTransaccional.General;
using AccesoDatos.NoTransaccional.SIMANET.GENERAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.GENERAL
{
    public  class CBusqueda
    {
        public DataTable BuscarProveedor(string Campo, string Valor, string UserName){ 
            return (new BusquedaNTAD()).BuscarProveedor(Campo, Valor, UserName);
        }

        public DataTable BuscarCIASeguro(string UserName)
        {
           return (new ItemTablaGeneralNTAD()).ListarTodos("454", UserName);
        }

    }
}
