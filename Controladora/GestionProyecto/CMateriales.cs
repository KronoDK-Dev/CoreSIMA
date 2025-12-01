using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{
    public class CMateriales
    {
        public DataTable Listar_det_gasto_pry_ot_uti(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new MaterialesNTAD()).Listar_det_gasto_pry_ot_uti(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        public DataTable Listar_det_gasto_pry_ot_vsm(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_PROYECTO, string UserName)
        {
            return (new MaterialesNTAD()).Listar_det_gasto_pry_ot_vsm(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_PROYECTO, UserName);
        }
    }
}
