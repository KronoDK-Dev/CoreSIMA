using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using AccesoDatos.NoTransaccional.GestionContabilidad;
using Controladora.GestionContabilidad;

namespace WSCore.GestionContabilidad
{
    /// <summary>
    /// Descripción breve de Contabilidad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Contabilidad : System.Web.Services.WebService
    {
        #region Procedimientos almacenados de clasificacion: Balance

        [WebMethod(Description = "Balance de Comprobación")]
        public DataTable Listar_balance_de_comprobacion(string D_MES, string D_PERIODO, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            return (new CBalance()).Listar_balance_de_comprobacion(D_MES, D_PERIODO, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, UserName);
        }

        [WebMethod(Description = "3. Balance a 8 Columnas ( Cta. 2 Digitos)")]
        public DataTable Listar_balance_10_Columnas_2_Digit(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            return (new CBalance()).Listar_balance_10_Columnas_2_Digit(N_CEO, V_ANIO, V_MES, UserName);
        }

        [WebMethod(Description = "4. Balance de Comprobación SUNAT")]
        public DataTable Listar_balance_de_comprobacion_SUNAT(string N_CEO, string V_ANIO, string V_MES, string V_CUENTAINI, string V_CUENTAFIN, string UserName)
        {
            return (new CBalance()).Listar_balance_de_comprobacion_SUNAT(N_CEO, V_ANIO, V_MES, V_CUENTAINI, V_CUENTAFIN, UserName);
        }

        [WebMethod(Description = "1. Balance de Comprobación PDT")]
        public DataTable Listar_balance_de_comprobacion_p(string D_AÑO, string D_MES, string D_MES_AJUSTE, string UserName)
        {
            return (new CBalance()).Listar_balance_de_comprobacion_p(D_AÑO, D_MES, D_MES_AJUSTE, UserName);
        }

        [WebMethod(Description = "1. Balance Constructivo MEF Sima Peru S.A.")]
        public DataTable Listar_balance_constructivo_mef(string D_AÑO, string D_MES, string D_MES_AJUSTE, string V_CODCEO, string UserName)
        {
            return (new CBalance()).Listar_balance_constructivo_mef(D_AÑO, D_MES, D_MES_AJUSTE, V_CODCEO, UserName);
        }

        [WebMethod(Description = "1. Balance de Comprobación SUSALUD")]
        public DataTable Listar_bal_constructivo_susalud(string D_AÑO, string D_MES, string UserName)
        {
            return (new CBalance()).Listar_bal_constructivo_susalud(D_AÑO, D_MES, UserName);
        }

        [WebMethod(Description = "4. Detalle     - Mayor Auxiliar")]
        public DataTable Listar_MaXAuxi_Pend_Det_Conci(string V_Cuenta, string D_Año, string D_Mes, string V_Relacion_Desde, string V_Relacion_Hasta, string V_Documento, string V_Menos_Subdiario, string UserName)
        {
            return (new CBalance()).Listar_MaXAuxi_Pend_Det_Conci(V_Cuenta, D_Año, D_Mes, V_Relacion_Desde, V_Relacion_Hasta, V_Documento, V_Menos_Subdiario, UserName);
        }

        [WebMethod(Description = "2. Balance de Comprobación 3 Digitos")]
        public DataTable Listar_balance_de_comprobacion_3_Digitos(string D_PERIODO, string D_MES, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            return (new CBalance()).Listar_balance_de_comprobacion_3_Digitos(D_PERIODO, D_MES, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Estados

        [WebMethod(Description = "Balance de Comprobación a 3 Digitos")]
        public DataTable Listar_analisis_cuentas_nat(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_CTA_MAYOR_DESDE, string V_CTA_MAYOR_HASTA, string V_C_COSTO_DESDE, string V_C_COSTO_HASTA, string UserName)
        {
            return (new CEstados()).Listar_analisis_cuentas_nat(D_AÑO, D_MES_DESDE, D_MES_HASTA, V_CENTRO_OPERATIVO, V_CTA_MAYOR_DESDE, V_CTA_MAYOR_HASTA, V_C_COSTO_DESDE, V_C_COSTO_HASTA, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar de Pendientes (Resumen por Relacion)")]
        public DataTable Listar_mayor_auxi_pend_rel_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new CEstados()).Listar_mayor_auxi_pend_rel_res(D_AÑO, D_MES, V_CUENTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = " Resumen - Conciliacion Bancaria ( Por Cta. Cte. )")]
        public DataTable Listar_conci_bancaria_resumen(string D_AÑO, string D_MES, string V_COD_BCO,
            string V_CUENTA_CORRIENTE, string UserName)
        {
            return (new CEstados()).Listar_conci_bancaria_resumen(D_AÑO, D_MES, V_COD_BCO, V_CUENTA_CORRIENTE, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar ( Resumen por Cuenta )")]
        public DataTable Listar_mayor_auxi_cuenta_resumen(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            return (new CEstados()).Listar_mayor_auxi_cuenta_resumen(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, UserName);
        }

        [WebMethod(Description = "2. Resumen - Mayor Auxiliar por Relacion")]
        public DataTable Listar_mayor_auxi_Rela_Resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new CEstados()).Listar_mayor_auxi_Rela_Resu(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Estado Proceso Contabilizacion de Logistica")]
        public DataTable Listar_Estado_del_Proceso(string UserName)
        {
            return (new CEstados()).Listar_Estado_del_Proceso(UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar de Pendientes ( Resumen por Cuenta )")]
        public DataTable Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(string V_Cuenta_Desde, string V_Cuenta_Hasta, string D_Año, string D_Mes, string UserName)
        {
            return (new CEstados()).Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(V_Cuenta_Desde, V_Cuenta_Hasta, D_Año, D_Mes, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: General

        [WebMethod(Description = "Centros de Costo ( Por Grupo de C.C. )")]
        public DataTable Listar_centros_de_costo(string V_CENTRO_OPERATIVO, string V_GRUPO_CC_DESDE, string V_GRUPO_CC_HASTA, string UserName)
        {
            return (new CGeneral()).Listar_centros_de_costo(V_CENTRO_OPERATIVO, V_GRUPO_CC_DESDE, V_GRUPO_CC_HASTA, UserName);
        }

        [WebMethod(Description = "Tipo de cambio monetario")]
        public DataTable Listar_tipo_de_cambio(string V_ANIO, string V_CODMND, string V_MESFIN, string V_MESINI, string UserName)
        {
            return (new CGeneral()).Listar_tipo_de_cambio(V_ANIO, V_CODMND, V_MESFIN, V_MESINI, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Operaciones

        [WebMethod(Description = "Resumen - Subdiario por Cuenta")]
        public DataTable Listar_subdiario_por_cuenta_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CUENTA, string V_SUBDIARIO, string UserName)
        {
            return (new COperaciones()).Listar_subdiario_por_cuenta_res(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_CUENTA, V_SUBDIARIO, UserName);
        }

        [WebMethod(Description = "Movimiento por Cuenta 91 y 92")]
        public DataTable Listar_mov_cuenta_91_92(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_mov_cuenta_91_92(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        [WebMethod(Description = "Plan de Cuentas General Empresarial 2019")]
        public DataTable Listar_plan_cuentas_pcge_2019(string V_CTA_FIN, string V_CTA_INI, string UserName)
        {
            return (new COperaciones()).Listar_plan_cuentas_pcge_2019(V_CTA_FIN, V_CTA_INI, UserName);
        }

        [WebMethod(Description = "Movimiento por Cuenta 96")]
        public DataTable Listar_movimiento_cuenta_96(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_movimiento_cuenta_96(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        [WebMethod(Description = "Asientos del Mes")]
        public DataTable Listar_asientos_por_subdiario(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            return (new COperaciones()).Listar_asientos_por_subdiario(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CUENTAFIN, V_CUENTAINI, V_MES, V_SUBDIARIO, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar de Pendientes (Resumen por Documento)")]
        public DataTable Listar_mayor_auxi_pend_doc_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_mayor_auxi_pend_doc_res(D_AÑO, D_MES, V_CUENTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Muestra: Mayor Auxiliar  (Resumen por Documento)")]
        public DataTable Listar_mayor_auxi_doc_resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_mayor_auxi_doc_resu(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Movimiento por Cuenta 97")]
        public DataTable Listar_movimiento_cuenta_97(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_movimiento_cuenta_97(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA, V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar  ( Detalle )")]
        public DataTable Listar_mayor_auxiliar_detalle(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_mayor_auxiliar_detalle(D_AÑO, D_MES, V_CUENTA_DESDE, V_CUENTA_HASTA, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar de Pendientes ( Detalle )")]
        public DataTable Listar_mayor_auxiliar_pend_deta(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION, string UserName)
        {

            return (new COperaciones()).Listar_mayor_auxiliar_pend_deta(D_AÑO, D_MES, V_CUENTA, V_DOCUMENTO, V_RELACION, UserName);
        }


        [WebMethod(Description = "Movimiento por Cuenta")]
        public DataTable Listar_movimiento_por_cuenta(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA,
            string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string V_CC, string UserName)
        {
            return (new COperaciones()).Listar_movimiento_por_cuenta(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA,
                V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, V_CC, UserName);
        }

        [WebMethod(Description = "Movimiento por Cuenta 2")]

        public string Listar_movimiento_por_cuenta2(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA,
          string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string V_CC, string UserName)
        {
            try
            {
                DataTable dt = (new COperaciones()).Listar_movimiento_por_cuenta(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CUENTA_DESDE, V_CUENTA_HASTA,
                    V_SUBDIARIO_DESDE, V_SUBDIARIO_HASTA, V_CC, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_MOVIMIENTO_POR_CUENTA";

                DataSet dset = new DataSet();
                dset.Tables.Add(dtCopy);

                using (StringWriter sw = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sw))
                    {
                        dset.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Asientos del Mes Solo subdiario020")]
        public DataTable Listar_asientos_por_subdiario_02(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CODDIV, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_NROOTS, string UserName)
        {
            return (new COperaciones()).Listar_asientos_por_subdiario_02(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CODDIV, V_CUENTAFIN, V_CUENTAINI, V_MES, V_NROOTS, UserName);
        }

        [WebMethod(Description = "Asientos del Mes ")]
        public DataTable Listar_asientos_subdiario_resu_c(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            return (new COperaciones()).Listar_asientos_subdiario_resu_c(D_DIAFIN, D_DIAINI, N_CEO, V_ANIO, V_ASIENTOFIN, V_ASIENTOINI, V_CENTROFIN, V_CENTROINI, V_CUENTAFIN, V_CUENTAINI, V_MES, V_SUBDIARIO, UserName);
        }

        [WebMethod(Description = "Tabulado de Subdiarios por CTA")]
        public DataTable Listar_tabulado_por_subdiarios(string V_ANIO, string V_CUENTA, string V_MES, string UserName)
        {
            return (new COperaciones()).Listar_tabulado_por_subdiarios(V_ANIO, V_CUENTA, V_MES, UserName);
        }

        [WebMethod(Description = "Mayor Auxiliar de Canceladas ( Detalle )")]
        public DataTable Listar_mayor_auxi_canceladas_det(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new COperaciones()).Listar_mayor_auxi_canceladas_det(D_AÑO, D_MES, V_CUENTA, V_DOCUMENTO, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Pagos

        [WebMethod(Description = "SUBDIARIO 011 FACTURAS POR PAGAR")]
        public DataTable Listar_voucher_por_documento(string V_NUMERO, string V_PROVEEDOR, string V_SERIE, string V_TIPO, string UserName)
        {
            return (new CPagos()).Listar_voucher_por_documento(V_NUMERO, V_PROVEEDOR, V_SERIE, V_TIPO, UserName);
        }

        [WebMethod(Description = "REGISTRO DEL REGIMEN DE RETENCIONES ")]
        public DataTable Listar_registro_retenciones_suna(string N_CEO, string V_ANIO, string V_NROMES, string UserName)
        {
            return (new CPagos()).Listar_registro_retenciones_suna(N_CEO, V_ANIO, V_NROMES, UserName);
        }

        [WebMethod(Description = "Pagos por la Cuenta Detraccion")]
        public DataTable Listar_pagos_por_cuenta_detraccion(string N_CEO, string V_ANIO, string V_MESFIN, string V_MESINI, string UserName)
        {
            return (new CPagos()).Listar_pagos_por_cuenta_detraccion(N_CEO, V_ANIO, V_MESFIN, V_MESINI, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Cobros

        [WebMethod(Description = "1. Registro de Ventas")]
        public DataTable Listar_registro_de_ventas(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_LINEA_NEGOCIO, string V_ORIGEN, string V_SERIE, string V_TIPO_DOCUMENTO, string UserName)
        {
            return (new CCobros()).Listar_registro_de_ventas(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_CONCEPTO, V_LINEA_NEGOCIO, V_ORIGEN, V_SERIE, V_TIPO_DOCUMENTO, UserName);
        }

        #endregion
    }
}
