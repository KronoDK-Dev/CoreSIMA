using AccesoDatos.NoTransaccional.GestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionProduccion
{
    public class CMantenimiento
    {
        public DataTable Listar_gasto_otx_fecha(string S_CEO, string S_CODDIV, string S_OT, string S_FINICIO, string S_FTERMINO, string UserName)
        {
            return (new MantenimientoNTAD()).Listar_gasto_otx_fecha(S_CEO, S_CODDIV, S_OT, S_FINICIO, S_FTERMINO, UserName);

        }

        public DataTable Listar_ots_se_v2(string S_CEO, string S_CODDIV, string S_OT, string S_FINICIO, string S_FTERMINO, string s_BIEN, string UserName)
        {
            return (new MantenimientoNTAD()).Listar_ots_se_v2(S_CEO, S_CODDIV, S_OT, S_FINICIO, S_FTERMINO, s_BIEN, UserName);

        }
        public DataTable Listar_ots_se(string S_CEO, string S_CODDIV, string S_OT, string S_FINICIO, string S_FTERMINO, string s_BIEN, string UserName)
        {
            return (new MantenimientoNTAD()).Listar_ots_se(S_CEO, S_CODDIV, S_OT, S_FINICIO, S_FTERMINO, s_BIEN, UserName);

        }
        public DataTable Listar_consumo_mat_ots(string S_CEO, string S_CODDIV, string S_OT, string S_FINICIO, string S_FTERMINO, string UserName)
        {
            return (new MantenimientoNTAD()).Listar_consumo_mat_ots(S_CEO, S_CODDIV, S_OT, S_FINICIO, S_FTERMINO, UserName);

        }

        public DataTable Listar_recursos_ots(string s_Anio, string UserName)
        {
            return (new MantenimientoNTAD()).Listar_recursos_ots(s_Anio, UserName);

        }
    }
}
