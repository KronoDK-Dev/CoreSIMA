using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CSubmarinos
    {
        public DataTable Listar_Registro_Ventas_Serie_021(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Tipo_Documento, string V_Origen, string V_Serie, string V_Concepto, string UserName)
        {
            return (new SubNTAD()).Listar_Registro_Ventas_Serie_021(V_Centro_Operativo, D_Año, D_Mes, V_Tipo_Documento, V_Origen,
                V_Serie, V_Concepto, UserName);
        }

        public DataTable Listar_Parte_Cobranzas_Serie_021(string V_Centro_Operativo, string D_Año_de_Proceso,
            string D_Mes, string UserName)
        {
            return (new SubNTAD()).Listar_Parte_Cobranzas_Serie_021(V_Centro_Operativo, D_Año_de_Proceso, D_Mes, UserName);
        }

        public DataTable Listar_DET_GASTO_PRY_OT_OSE_AVASU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string V_NROOTS, string UserName)
        {
            return (new SubNTAD()).Listar_DET_GASTO_PRY_OT_OSE_AVASU(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS, UserName);
        }

        public DataTable Listar_DET_GASTO_PRY_OT_MOB_RUCSU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new SubNTAD()).Listar_DET_GASTO_PRY_OT_MOB_RUCSU(N_CEO, V_CODDIV, V_CODPRY, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_Egresos_Directos_PRCS(string V_Centro_Operativo, string D_Año, string D_Mes_Desde,
            string D_Mes_Hasta, string UserName)
        {
            return (new SubNTAD()).Listar_Egresos_Directos_PRCS(V_Centro_Operativo, D_Año, D_Mes_Desde, D_Mes_Hasta, UserName);
        }

        public DataTable Listar_Mayor_Auxiliar_Cancelada(string v_anio, string v_mes, string v_cta, string v_ruc1,
            string v_ruc2, string v_docu, string UserName)
        {
            return (new SubNTAD()).Listar_Mayor_Auxiliar_Cancelada(v_anio, v_mes, v_cta, v_ruc1, v_ruc2, v_docu, UserName);
        }
    }
}
