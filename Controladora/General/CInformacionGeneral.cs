using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public  class CInformacionGeneral
    {
        public DataTable ListarInterfaceWService(int IdServiceMetodo, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListarInterfaceWService(IdServiceMetodo, UserName);
        }
    }
}
