using Controladora.GestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{
    public class COt
    {
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string AÑO, string UserName)
        {
            return (new OtNTAD()).Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, AÑO, UserName);
        }

        public DataTable Listar_detg_pry_ot_sinfact_test(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string AÑO, string UserName)
        {
            return (new OtNTAD()).Listar_detg_pry_ot_sinfact_test(CENTRO_OPERATIVO, DIVISION, PROYECTO, AÑO, UserName);
        }

        public DataTable Listar_ots_por_proyecto(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new OtNTAD()).Listar_ots_por_proyecto(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }
    }
}
