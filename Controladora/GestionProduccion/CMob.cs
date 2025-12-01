using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;
using Oracle.DataAccess.Client;

namespace Controladora.GestionProduccion
{
    public class CMob
    {
        public DataTable Listar_vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            return (new MobNTAD()).Listar_vacaciones(D_PERIODO, V_CO, V_ROL, UserName);
        }

        public DataTable Listar_novedades_paus(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            return (new MobNTAD()).Listar_novedades_paus(N_CEO, V_CODUNS, V_PERIODO, UserName);
        }

        public DataTable Listar_mob_x_fecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return (new MobNTAD()).Listar_mob_x_fecha(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }

        public OracleDataReader Listar_mob_x_fecha_reader(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return (new MobNTAD()).Listar_mob_x_fecha_reader(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }

        public DataTable Listar_mob_x_fecha_xProy2(string N_CEO, string V_PROYECTO, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new MobNTAD()).Listar_mob_x_fecha_xProy2(N_CEO, V_PROYECTO, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_lista_saldo_mo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return (new MobNTAD()).Listar_lista_saldo_mo(N_CEO, V_CATVCRV, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
        }

        public DataTable Listar_detalle_mob(string V_CO, string V_DIVISION, string V_OT, string d_fechaini,
            string d_fecha_fin, string UserName)
        {
            return (new MobNTAD()).Listar_detalle_mob(V_CO, V_DIVISION, V_OT, d_fechaini, d_fecha_fin, UserName);
        }

        public DataTable Listar_mob(string D_AÑO, string D_MESINI, string D_MESFIN, string UserName)
        {
            return (new MobNTAD()).Listar_mob(D_AÑO, D_MESINI, D_MESFIN, UserName);
        }

        public DataTable Listar_Lista_mob_pago(string V_rol, string V_tiphex, string V_CentroCostoDesde,
            string V_CentroCostoHasta, string UserName)
        {
            return (new MobNTAD()).Listar_Lista_mob_pago(V_rol, V_tiphex, V_CentroCostoDesde, V_CentroCostoHasta, UserName);
        }

        public DataTable Listar_Lista_mob_pago2(string V_rol, string V_tiphex, string V_CentroCostoDesde,
            string V_CentroCostoHasta, string UserName)
        {
            return (new MobNTAD()).Listar_Lista_mob_pago(V_rol, V_tiphex, V_CentroCostoDesde, V_CentroCostoHasta, UserName);
        }

        public DataTable Listar_Res_Lista_mob_pago(string V_tiphex, string UserName)
        {
            return (new MobNTAD()).Listar_Res_Lista_mob_pago(V_tiphex, UserName);
        }

        public DataTable Listar_MobXFechaOt(string v_Centro_Operativo, string v_Division, string v_OT, string UserName)
        {
            return (new MobNTAD()).Listar_MobXFechaOt(v_Centro_Operativo, v_Division, v_OT, UserName);
        }

        public DataTable Listar_DETALLE_GASTO_PRY_OT_MOBSU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new MobNTAD()).Listar_DETALLE_GASTO_PRY_OT_MOBSU(N_CEO, V_CODDIV, V_CODPRY, D_FECHAINI, D_FECHAFIN, UserName);
        }
    }
}
