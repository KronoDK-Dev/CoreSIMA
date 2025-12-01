using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{
    public class COrdenes
    {
        public DataTable Listar_det_gasto_pry_ot_ose_ava(string N_CEO, string V_CODDIV, string V_CODPRY, string V_ORDSRV, string UserName)
        {
            return (new OrdenesNTAD()).Listar_det_gasto_pry_ot_ose_ava(N_CEO, V_CODDIV, V_CODPRY, V_ORDSRV, UserName);
        }

        public DataTable Listar_detalle_gasto_pry_ot_ose(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new OrdenesNTAD()).Listar_detalle_gasto_pry_ot_ose(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        public DataTable Listar_det_gasto_pry_ot_oco(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new OrdenesNTAD()).Listar_det_gasto_pry_ot_oco(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        public DataTable Listar_resumen_ose(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new OrdenesNTAD()).Listar_resumen_ose(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        public DataTable Listar_detalle_ose_femision(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return (new OrdenesNTAD()).Listar_detalle_ose_femision(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }
    }
}
