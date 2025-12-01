using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CGeneral
    {
        public DataTable Listar_tarifa_maq(string V_TALLER, string UserName)
        {
            return (new GeneralNTAD()).Listar_tarifa_maq(V_TALLER, UserName);
        }
    }
}
