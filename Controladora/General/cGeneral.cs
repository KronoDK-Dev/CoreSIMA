using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public class cGeneral
    {
        public string LISTA_DESCRIP_ERRORES(string c_errores, string UserName)
        {
            return (new InformacionGeneralNTAD()).LISTA_DESCRIP_ERRORES(c_errores, UserName);
        }
    }
}
