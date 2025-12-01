using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{
    public class CPagos
    {
        public DataTable Listar_resumen_ose_partida(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new PagosNTAD()).Listar_resumen_ose_partida(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        public DataTable Listar_det_gto_mat_pry_ot_partid(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new PagosNTAD()).Listar_det_gto_mat_pry_ot_partid(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        public DataTable Listar_det_gast_pry_ot_oco_ate_acu(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new PagosNTAD()).Listar_det_gast_pry_ot_oco_ate_acu(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        public DataTable Listar_gastos_proyectos_ot_v3(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return (new PagosNTAD()).Listar_gastos_proyectos_ot_v3(N_CEO, V_CODDIV, V_CODPRY, UserName);
        }
    }
}
