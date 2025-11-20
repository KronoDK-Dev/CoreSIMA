using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionContabilidad;

namespace Controladora.GestionContabilidad
{
    public class COperaciones
    {
        public DataTable Listar_subdiario_por_cuenta_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CUENTA, string V_SUBDIARIO, string UserName)
        {
            return (new OperacionesNTAD()).Listar_subdiario_por_cuenta_res(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_CUENTA, V_SUBDIARIO, UserName);
        }

        public DataTable Listar_mov_cuenta_91_92(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mov_cuenta_91_92(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        public DataTable Listar_plan_cuentas_pcge_2019(string V_CTA_FIN, string V_CTA_INI, string UserName)
        {
            return (new OperacionesNTAD()).Listar_plan_cuentas_pcge_2019(V_CTA_FIN, V_CTA_INI, UserName);
        }

        public DataTable Listar_movimiento_cuenta_96(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_movimiento_cuenta_96(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        public DataTable Listar_asientos_por_subdiario_02(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CODDIV, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_NROOTS, string UserName)
        {
            return (new OperacionesNTAD()).Listar_asientos_por_subdiario_02(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CODDIV, V_CUENTAFIN, V_CUENTAINI, V_MES, V_NROOTS, UserName);
        }

        public DataTable Listar_mayor_auxi_pend_doc_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mayor_auxi_pend_doc_res(D_AÑO, D_MES, V_CUENTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_mayor_auxi_doc_resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mayor_auxi_doc_resu(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_movimiento_cuenta_97(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_movimiento_cuenta_97(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        public DataTable Listar_mayor_auxiliar_detalle(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mayor_auxiliar_detalle(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_mayor_auxiliar_pend_deta(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mayor_auxiliar_pend_deta(D_AÑO, D_MES, V_CUENTA, V_DOCUMENTO, V_RELACION, UserName);
        }

        public DataTable Listar_movimiento_por_cuenta(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string V_CC, string UserName)
        {
            return (new OperacionesNTAD()).Listar_movimiento_por_cuenta(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, V_CC, UserName);
        }

        public DataTable Listar_asientos_subdiario_resu_c(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            return (new OperacionesNTAD()).Listar_asientos_subdiario_resu_c(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CUENTAFIN, V_CUENTAINI, V_MES, V_SUBDIARIO, UserName);
        }

        public DataTable Listar_tabulado_por_subdiarios(string V_ANIO, string V_CUENTA, string V_MES, string UserName)
        {
            return (new OperacionesNTAD()).Listar_tabulado_por_subdiarios(V_ANIO, V_CUENTA, V_MES, UserName);
        }

        public DataTable Listar_mayor_auxi_canceladas_det(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new OperacionesNTAD()).Listar_mayor_auxi_canceladas_det(D_AÑO, D_MES, V_CUENTA, V_DOCUMENTO, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_asientos_por_subdiario(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            return (new OperacionesNTAD()).Listar_asientos_por_subdiario(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CUENTAFIN, V_CUENTAINI, V_MES, V_SUBDIARIO, UserName);
        }
    }
}
