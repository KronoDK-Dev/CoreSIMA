using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;

namespace Controladora.General
{
    public class cCentroCosto
    {
        public DataTable BuscarCentrosCosto(string NombreCC, string UserName)
        {
            return (new InformacionGeneralNTAD()).BuscarCentrosCosto(NombreCC, UserName);
        }

        public DataTable BuscarCentrosCosto(string N_COD_EMP, string V_NOMBRE_CC, string UserName)
        {
            return (new InformacionGeneralNTAD()).BuscarCentrosCosto(N_COD_EMP, V_NOMBRE_CC, UserName);
        }

        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListarCentroOperativoPorPerfil(IdUsuario, UserName);
        }
    }
}
