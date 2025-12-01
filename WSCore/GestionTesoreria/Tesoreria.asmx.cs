using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionTesoreria;

namespace WSCore.GestionTesoreria
{
    /// <summary>
    /// Descripción breve de Tesoreria
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Tesoreria : System.Web.Services.WebService
    {
        #region PROCEDIMIENTOS ALMACENADOS DE CLASIFICACION: BALANCE

        [WebMethod(Description = "Conciliacion Bancaria Conciliados")]
        public DataTable Listar_conci_banc_r_cartola_conc(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return (new cBalance()).Listar_conci_banc_r_cartola_conc(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO,
                V_MONEDA, UserName);
        }

        [WebMethod(Description = "Conciliacion Bancaria Cartola Resumen")]
        public DataTable Listar_conci_bancaria_res_cartol(string D_AÑO, string D_MES, string V_CARTOLA,
            string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return (new cBalance()).Listar_conci_bancaria_res_cartol(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO,
                V_MONEDA, UserName);
        }

        [WebMethod(Description = "Conciliacion Bancaria Cartola")]
        public DataTable Listar_conciliacion_banc_cartola(string D_AÑO, string D_MES, string V_CARTOLA,
            string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return (new cBalance()).Listar_conciliacion_banc_cartola(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO,
                V_MONEDA, UserName);
        }

        [WebMethod(Description = "Detalle - F.F. GERENCIA FINANCIERA ( Por Trabajador )")]
        public DataTable Listar_detalle_ffj_gf(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            return (new cBalance()).Listar_detalle_ffj_gf(D_AÑO, V_LIQUIDACION, UserName);
        }

        [WebMethod(Description = "Libro Banco")]
        public DataTable Listar_libro_banco(string D_AÑO, string D_MES, string V_BANCO, string V_CENTRO_OPERATIVO,
            string V_CUENTA_CORRIENTE, string UserName)
        {
            return (new cBalance()).Listar_libro_banco(D_AÑO, D_MES, V_BANCO, V_CENTRO_OPERATIVO, V_CUENTA_CORRIENTE, UserName);
        }

        [WebMethod(Description = "Resumen - F.F. GERENCIA FINANCIERA ( Por C.Costo ) - movilidad")]
        public DataTable Listar_res_ffj_x_centro_costos(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            return (new cBalance()).Listar_res_ffj_x_centro_costos(D_AÑO, V_LIQUIDACION, UserName);
        }

        [WebMethod(Description = "Cheques y Egresos Directos por Mes")]
        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            return (new cBalance()).Listar_cheques_egresos_directos(D_AÑO, D_MES_DESDE, D_MES_HASTA, V_CENTRO_OPERATIVO, V_MONEDA, V_TIPO_DE_OPERACION, UserName);
        }

        [WebMethod(Description = "5. Estado de Cuenta por Documento Electronico")]
        public DataTable Listar_Estado_Cuenta_Doc_Elect(string V_Centro_Operativo, string V_Documento, string V_Nro_de_Serie, string V_Nro_Correlativo, string UserName)
        {
            return (new cBalance()).Listar_Estado_Cuenta_Doc_Elect(V_Centro_Operativo, V_Documento, V_Nro_de_Serie, V_Nro_Correlativo, UserName);
        }

        [WebMethod(Description = "6. Estado de Cuenta por Documento No Electronico")]
        public DataTable Listar_Estado_de_Cuenta_por_Doc(string V_Centro_Operativo, string V_Documento, string V_Nro_de_Serie, string V_Nro_Correlativo, string UserName)
        {
            return (new cBalance()).Listar_Estado_de_Cuenta_por_Doc(V_Centro_Operativo, V_Documento, V_Nro_de_Serie, V_Nro_Correlativo, UserName);
        }

        #endregion

        #region PROCEDIMIENTOS ALMACENADOS DE CLASIFICACION: COBROS

        [WebMethod(Description = "Folios Pendientes de O7")]
        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            return (new cCobros()).Listar_folios_pendientes_o7(D_AÑO, D_MES, UserName);
        }

        [WebMethod(Description = "Ingresos")]
        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE,
            string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            return (new cCobros()).Listar_ingresos_contabilizados(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CONCEPTO,
                V_DESDE, V_EMPRESA_DESDE, V_EMPRESA_HASTA, V_HASTA, V_MONEDA, UserName);
        }

        [WebMethod(Description = "Ventas por Orden de Trabajo")]
        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT,
            string UserName)
        {
            return (new cCobros()).Listar_ventas_x_orden_trabajo(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT,
                UserName);
        }

        [WebMethod(Description = "Facturas por Cobrar - Sector Privado")]
        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            return (new cCobros()).Listar_fact_cobrar_sector_privado(UserName);
        }

        [WebMethod(Description = "Facturas por Cobrar - Sector Marina")]
        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            return (new cCobros()).Listar_fact_cobrar_sector_marina(UserName);
        }

        [WebMethod(Description = "1. Detalle - Parte de Cobranzas")]
        public DataTable Listar_Parte_de_Cobranzas(string V_Centro_Operativo, string D_Año, string D_Mes, string UserName)
        {
            return (new cCobros()).Listar_Parte_de_Cobranzas(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        [WebMethod(Description = "2. Detalle - Documentos por Cliente")]
        public DataTable Listar_Documentos_por_Cliente(string V_Centro_Operativo, string V_Cliente, string D_Año_Desde, string D_Año_Hasta, string UserName)
        {
            return (new cCobros()).Listar_Documentos_por_Cliente(V_Centro_Operativo, V_Cliente, D_Año_Desde, D_Año_Hasta, UserName);
        }

        [WebMethod(Description = "4. Facturación Mensual por Linea Negocio")]
        public DataTable Listar_Fact_Men_X_Linea_Neg(string V_Centro_Operativo, string D_Año, string UserName)
        {
            return (new cCobros()).Listar_Fact_Men_X_Linea_Neg(V_Centro_Operativo, D_Año, UserName);
        }

        [WebMethod(Description = "7. Datos Generales de la Orden de Trabajo")]
        public DataTable Listar_Orden_Trabajo_Datos_Gener(string V_Centro_Operativo, string V_Division, string V_Numero_OT, string UserName)
        {
            return (new cCobros()).Listar_Orden_Trabajo_Datos_Gener(V_Centro_Operativo, V_Division, V_Numero_OT, UserName);
        }

        [WebMethod(Description = "8. Anexo OT Diques")]
        public DataTable Listar_Anexo_Diques(string V_Centro_Operativo, string V_Division, string V_Numero_OT, string UserName)
        {
            return (new cCobros()).Listar_Anexo_Diques(V_Centro_Operativo, V_Division, V_Numero_OT, UserName);
        }

        #endregion

        #region PROCEDIMIENTOS ALMACENADOS DE CLASIFICACIOON: PAGOS

        [WebMethod(Description = "Detalle  - Cheque  Girado por Numero")]
        public DataTable Listar_cheque_giradoxnum(string V_CENTRO_OPERATIVO, string V_CHEQUE_NUMERO, string UserName)
        {
            return (new cPagos()).Listar_cheque_giradoxnum(V_CENTRO_OPERATIVO, V_CHEQUE_NUMERO, UserName);
        }
        
        [WebMethod(Description = "Resumen - Cheques Emitidos")]
        public DataTable Listar_cheques_emitidos_resumen(string D_AÑO, string V_CENTRO_OPERATIVO, string UserName)
        {
            return (new cPagos()).Listar_cheques_emitidos_resumen(D_AÑO, V_CENTRO_OPERATIVO, UserName);
        }

        [WebMethod(Description = "Detalle - Cheques Girados por Relacion")]
        public DataTable Listar_cheques_giradosxprove_det(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new cPagos()).Listar_cheques_giradosxprove_det(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO,
                V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Resumen - Cheques Girados por Relacion")]
        public DataTable Listar_cheques_giradosxprove_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new cPagos()).Listar_cheques_giradosxprove_res(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_RELACION_DESDE,
                V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Resumen - Cheques Girados por Observacion")]
        public DataTable Listar_cheques_por_observacion(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_OBSERVACION, string UserName)
        {
            return (new cPagos()).Listar_cheques_por_observacion(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO,
                V_OBSERVACION, UserName);
        }

        [WebMethod(Description = "Detalle - Lote de Detracion por Documento")]
        public DataTable Listar_lote_de_detrac_por_doc(string V_CENTRO_OPERATIVO, string V_NUMERO_DE_LOTE, string UserName)
        {
            return (new cPagos()).Listar_lote_de_detrac_por_doc(V_CENTRO_OPERATIVO, V_NUMERO_DE_LOTE, UserName);
        }

        [WebMethod(Description = "Facturas x Pagar - Pendientes")]
        public DataTable Listar_fact_pagar_pendientes(string V_RECURSO, string V_RUC, string V_PROYECTO, string UserName)
        {
            return (new cPagos()).Listar_fact_pagar_pendientes(V_RECURSO, V_RUC, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Facturas x Pagar - Pendientes del Periodo Anterior")]
        public DataTable Listar_fact_por_pagar_doc(string D_AÑO, string D_MES, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return (new cPagos()).Listar_fact_por_pagar_doc(D_AÑO, D_MES, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        [WebMethod(Description = "Facturas x Pagar - Total")]
        public DataTable Listar_facturas_por_pagar_total(string UserName)
        {
            return (new cPagos()).Listar_facturas_por_pagar_total(UserName);
        }

        [WebMethod(Description = "Pagos a proveedores")]
        public DataTable Listar_pago_proveedores(string V_SUCURSAL, string V_RUC_INI, string V_RUC_FIN, string v_fecha_ini, string v_fecha_fin,
                                                 string v_operacion, string UserName)
        {
            return (new cPagos()).Listar_pago_proveedores(V_SUCURSAL, V_RUC_INI, V_RUC_FIN, v_fecha_ini, v_fecha_fin, v_operacion, UserName);
        }

        [WebMethod(Description = "Pagos de Facturas")]
        public DataTable Listar_pago_Facturas(string V_SUCURSAL, string V_RUC_INI, string V_RUC_FIN, string v_fecha_ini, string v_fecha_fin,
                                         string v_operacion, string UserName)
        {
            return (new cPagos()).Listar_pago_Facturas(V_SUCURSAL, V_RUC_INI, V_RUC_FIN, v_fecha_ini, v_fecha_fin, v_operacion, UserName);
        }

        [WebMethod(Description = "Lista Líneas de Negocio")]
        public DataTable ListaLineas(string UserName)
        {
            return (new cPagos()).ListaLineas(UserName);
        }

        [WebMethod(Description = "Proyectos - Sin Dependencia")]
        public DataTable ListaProyectosSinDep(string V_NOMBRE, string UserName)
        {
            return (new cPagos()).ListaProyectosSinDep(V_NOMBRE, UserName);
        }

        #endregion
    }
}
