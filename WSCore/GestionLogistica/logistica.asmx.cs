using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Controladora.GestionLogistica;

namespace WSCore.GestionLogistica
{
    /// <summary>
    /// Descripción breve de logistica
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class logistica : System.Web.Services.WebService
    {

        #region Procedimientos almacenados de clasificacion: ORDENES

        [WebMethod(Description = "Muestra la ordenes de servicio atendidas en un rango de fechas de atenci¿n")]
        public DataTable Listar_OrdenComP_VFechaEntre(string Centro_Operativo, string Procedencia, string Fecha_Inicio,
            string Fecha_Termino, string Clase_Material, string UserName)
        {
            return (new cOrdenes()).Listar_OrdenComP_VFechaEntre(Centro_Operativo, Procedencia, Fecha_Inicio, Fecha_Termino, Clase_Material, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA GENERADAS")]
        public DataTable Listar_OcoEmiContral(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return (new cOrdenes()).Listar_OcoEmiContral(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Inicial, Fecha_Final, UserName);
        }

        [WebMethod(Description = "Lista O/C generadas para tipo de programas de Reposición de Stock.")]
        public DataTable Listar_ordcompraporrepo(string DESTINO_COMPRA, string FECHA_MOVIMIENTO_INICIO,
            string FECHA_MOVIMIENTO_TERMINO, string MATERIAL_FINAL,
            string MATERIAL_INICIAL, string UserName)
        {
            return (new cOrdenes()).Listar_ordcompraporrepo(DESTINO_COMPRA, FECHA_MOVIMIENTO_INICIO,
                FECHA_MOVIMIENTO_TERMINO, MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIOS")]
        public DataTable Listar_OrdServicioLond(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string Procedencia, string UserName)
        {
            return (new cOrdenes()).Listar_OrdServicioLond(Fecha_Emision_Inicio, Fecha_Emision_Termino, Procedencia, UserName);
        }

        [WebMethod(Description = "MODIFICACION DE FECHA DE ENTREGA EN ORDENES DE COMPRA Y SERVICIOS")]
        public DataTable Listar_ModiFEntreOcoOse(string Centro_Operativo, string Tipo_Orden, string Procedencia,
            string Numero_Orden, string UserName)
        {
            return (new cOrdenes()).Listar_ModiFEntreOcoOse(Centro_Operativo, Tipo_Orden, Procedencia, Numero_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS EMITIDAS(Solicitado para proporcionar información a Contraloría)")]
        public DataTable Listar_OcoEmiLogi(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Emision_Inicial, string Fecha_Emision_Final, string Cotizador, string UserName)
        {
            return (new cOrdenes()).Listar_OcoEmiLogi(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Emision_Inicial,
                Fecha_Emision_Final, Cotizador, UserName);
        }

        [WebMethod(Description = "Muestra la ordenes de servicio atendidas en un rango de fechas de atenci¿n")]
        public DataTable Listar_AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_AVANCE_OSE_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Muestra la ordenes de compra dispuestas en almacenamiento en un rango de fechas")]
        public DataTable Listar_ALMAC_OCO_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_ALMAC_OCO_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Muestra las atenciones de los servicios que provienen de las: OS/Rend.Cta./Fondos Fijos, de cada centro de costos en un rango de fechas")]
        public DataTable Listar_AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI,
            string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_AtencionesServiciosCC(N_CEO, V_CODCCO, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "REQUERIMIENTOS DE ORDENES DE COMPRA")]
        public DataTable Listar_REQUERIMIENTO_OCO_VALJDE(string Fecha_Emision, string UserName)
        {
            return (new cOrdenes()).Listar_REQUERIMIENTO_OCO_VALJDE(Fecha_Emision, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA")]
        public DataTable Listar_OCO_OGC(string Centro_Operativo, string Procedencia, string año_de_Orden,
            string UserName)
        {
            return (new cOrdenes()).Listar_OCO_OGC(Centro_Operativo, Procedencia, año_de_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO")]
        public DataTable Listar_OSE_OGC(string Centro_Operativo, string año_de_Orden, string UserName)
        {
            return (new cOrdenes()).Listar_OSE_OGC(Centro_Operativo, año_de_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR DIVISIONES")]
        public DataTable Listar_LOG_OSE_OTS_RN(string V_Centro_Operativo, string V_división,
            string D_Fecha_Emision_OSE_Inicio, string D_Fecha_Emision_OSE_Termino, string UserName)
        {
            return (new cOrdenes()).Listar_LOG_OSE_OTS_RN(V_Centro_Operativo, V_división, D_Fecha_Emision_OSE_Inicio,
                D_Fecha_Emision_OSE_Termino, UserName);
        }

        [WebMethod(Description = "Muestra: Las Ordenes de Servicio por  Rango de Fecha Emision")]
        public DataTable Listar_OrdenesServicioCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_OrdenesServicioCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Las Ordenes de Compra de Materiales por  Rango de Fecha Emision")]
        public DataTable Listar_OrdenesCompraCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_OrdenesCompraCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS Y SERVICIOS RELACIONADAS A OT")]
        public DataTable Listar_ORDENCOM_SER_OT_CONTRALORIA(string Centro_Operativo, string DIVISION,
            string ORDEN_DE_TRABAJO, string UserName)
        {
            return (new cOrdenes()).Listar_ORDENCOM_SER_OT_CONTRALORIA(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO,
                UserName);
        }

        [WebMethod(Description = "Ordenes con fecha de ultima entrega y facturas de proveedores")]
        public DataTable Listar_Ordenes_Entrega_FacPrv(string FECHA_INICIAL, string FECHA_FINAL, string TIPO_DE_ORDEN,
            string PROCEDENCIA, string UserName)
        {
            return (new cOrdenes()).Listar_Ordenes_Entrega_FacPrv(FECHA_INICIAL, FECHA_FINAL, TIPO_DE_ORDEN,
                PROCEDENCIA, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_Egresos_Directos_OCO(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cOrdenes()).Listar_Egresos_Directos_OCO(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS Y SERVICIOS RELACIONADAS A OT ")]
        public DataTable Listar_ORDENES_COM_SER_OT(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO,
            string UserName)
        {
            return (new cOrdenes()).Listar_ORDENES_COM_SER_OT(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS Y SERVICIOS RELACIONADAS A OT - XML STRING")]
        public string Listar_ORDENES_COM_SER_OT2(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO,
           string UserName)
        {

            try
            {
                DataTable dt = (new cOrdenes()).Listar_ORDENES_COM_SER_OT(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_ORDENES_COM_SER_OT"; // este es el nombre del procedimiento que alimentará al reporte crystal, asi que debe coincidir

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

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505.")]
        public DataTable Listar_DIF_CMB_PRY_OSE(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_OSE(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS - (DIFERENCIAL CAMBIARIO)  (String xml) | basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505.")]
        public string Listar_DIF_CMB_PRY_OSE2(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            try
            {
                DataTable dt = (new cOrdenes()).Listar_DIF_CMB_PRY_OSE2(Centro_Operativo, división, Proyecto, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_DIF_CMB_PRY_OSE";

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

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OSE_MNT_AVA(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_OSE_MNT_AVA(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "EGRESOS DIRECTOS POR PROYECTOS (DIFERENCIAL CAMBIARIO) basado en ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OCO(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_OCO(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505 vers.2")]
        public string Listar_DIF_CMB_PRY_OCO_V2(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            try
            {
                DataTable dt = (new cOrdenes()).Listar_DIF_CMB_PRY_OCO(Centro_Operativo, división, Proyecto, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_DIF_CMB_PRY_OCO";

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

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS (String XML) INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505 vers.2")]
        public string Listar_DIF_CMB_PRY_OCO2(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            try
            {
                DataTable dt = (new cOrdenes()).Listar_DIF_CMB_PRY_OCO2(Centro_Operativo, división, Proyecto, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_DIF_CMB_PRY_OCO"; // este es el nombre del procedimiento que alimentará al reporte crystal, asi que debe coincidir

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

        [WebMethod(Description = "AVANCE DE PAGOS DE ORDENES DE SERVICIO")]
        public DataTable Listar_OseAvance(string FECHA_EMISION_INICIAL, string FECHA_EMISION_FINAL, string NMRO_OSE,
            string UserName)
        {
            return (new cOrdenes()).Listar_OseAvance(FECHA_EMISION_INICIAL, FECHA_EMISION_FINAL, NMRO_OSE, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OCO_PCI(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_OCO_PCI(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OCO_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string Numero_Orden, string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_OCO_SIN_OT(Centro_Operativo, división, Proyecto, Numero_Orden,
                UserName);
        }

        [WebMethod(Description = "EGRESOS DIRECTOS POR PROYECTOS (DIFERENCIAL CAMBIARIO) basado en ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_EGR_DIR(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return (new cOrdenes()).Listar_DIF_CMB_PRY_EGR_DIR(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ALMACENAMIENTO DE ORDENES DE COMPRA POR PERIODO")]
        public DataTable Listar_ALM_OCO_ATE_RSV(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO,
            string V_DESTINO_COMPRA, string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            return (new cOrdenes()).Listar_ALM_OCO_ATE_RSV(D_INICIO_ALMACENAMIENTO, D_FINAL_ALMACENAMIENTO,
                V_DESTINO_COMPRA, V_Filtro_PRY_AUS, V_PRY_AUS, UserName);
        }

        [WebMethod(Description = "ALMACENAMIENTO DE ORDENES DE COMPRA POR PERIODO vers.2")]
        public string Listar_ALM_OCO_ATE_RSV2(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO,
            string V_DESTINO_COMPRA, string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            try
            {
                DataTable dt = (new cOrdenes()).Listar_ALM_OCO_ATE_RSV(D_INICIO_ALMACENAMIENTO, D_FINAL_ALMACENAMIENTO,
                V_DESTINO_COMPRA, V_Filtro_PRY_AUS, V_PRY_AUS, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_ALM_OCO_ATE_RSV";

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

        [WebMethod(Description = "1.OrdenCompraPaquete_EmbarqueDetalle")]
        public DataTable Listar_emb_det_v1(string V_ORCOMPRA, string V_EMBARQUE,
           string V_DIFERENCIA, string V_CODMAT, string UserName)
        {
            return (new cOrdenes()).Listar_emb_det_v1(V_ORCOMPRA, V_EMBARQUE,
            V_DIFERENCIA, V_CODMAT, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_OrdenCompraTPaqv1(string ORDEN_COMPRA, string UserName)
        {
            return (new cOrdenes()).Listar_OrdenCompraTPaqv1(ORDEN_COMPRA, UserName);
        }

        [WebMethod(Description = "")]
        public string Listar_Emb_det_mov_v1(string N_CEO, string V_ORCOMPRA, string V_EMBARQUE, string V_CODMAT, string UserName)
        {
            try
            {
                DataTable dt = (new cOrdenes()).Listar_Emb_det_mov_v1(N_CEO, V_ORCOMPRA, V_EMBARQUE, V_CODMAT, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_EMB_DET_MOV_V1";

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
            //return (new cOrdenes()).Listar_Emb_det_mov_v1(N_CEO, V_ORCOMPRA, V_EMBARQUE, V_CODMAT, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Lista_OT_RELACIONADAS_OCO(string V_CEO, string V_Nro_Orden, string V_Procedencia, string UserName)
        {
            return (new cOrdenes()).Lista_OT_RELACIONADAS_OCO(V_CEO, V_Nro_Orden, V_Procedencia, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: GENERAL

        [WebMethod(Description = "Tablas Generales - EQUIVALENCIAS GENERICAS (CONVERSION) DE UNIDADES DE MEDIDA")]
        public DataTable Listar_TG_EQUIVALENICIASGENERICAS(string UserName)
        {
            return (new cGeneral()).Listar_TG_EQUIVALENICIASGENERICAS(UserName);
        }

        [WebMethod(Description = "Tablas Generales - EQUIVALENCIAS POR MATERIAL (CONVERSION) DE UNIDADES DE MEDIDA")]
        public DataTable Listar_TG_EQUIVALENICIASPORMATERIA(string UserName)
        {
            return (new cGeneral()).Listar_TG_EQUIVALENICIASPORMATERIA(UserName);
        }

        [WebMethod(Description = "Tablas Generales - UNIDADES DE MEDIDA")]
        public DataTable Listar_Tg_Unidad_Medida(string UserName)
        {
            return (new cGeneral()).Listar_Tg_Unidad_Medida(UserName);
        }

        [WebMethod(Description = "Tablas Generales - UNIDADES DE MEDIDA FILTRADO POR UNIDAD")]
        public DataTable Listar_Tg_Unidad_Medida2(string unidad, string UserName)
        {
            return (new cGeneral()).Listar_Tg_Unidad_Medida2(unidad, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: MATERIALES

        [WebMethod(Description = "Lista consumo Anual de materiales por Vales de Salida en el almacén")]
        public DataTable Listar_ConsumoAnualMateriales(string N_CEO, string PERIODO, string TIPO,
            string CLASIFICACION, string UserName)
        {
            return (new cMateriales()).Listar_ConsumoAnualMateriales(N_CEO, PERIODO, TIPO, CLASIFICACION, UserName);
        }

        [WebMethod(Description = "Materiales por Centro Operativo")]
        public DataTable Listar_Mat_CentroOperativo(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string UserName)
        {
            return (new cMateriales()).Listar_Mat_CentroOperativo(Fecha_Emision_Inicio, Fecha_Emision_Termino,
                UserName);
        }

        [WebMethod(Description = "MATERIAL LLEGADO DE COMPRAS")]
        public DataTable Listar_MatLLegadoCompras(string Codigo_Division, string Codigo_OT, string Fecha_LLegada_Inicio,
            string Fecha_Llegada_Termino, string UserName)
        {
            return (new cMateriales()).Listar_MatLLegadoCompras(Codigo_Division, Codigo_OT, Fecha_LLegada_Inicio,
                Fecha_Llegada_Termino, UserName);
        }

        [WebMethod(Description = "Muestra el  CATALOGO DE MATERIALES por rango de fechas de creación")]
        public DataTable Listar_CatalogoMaterialesFC(string D_FechaIEmision, string D_FechaFEmision, string UserName)
        {
            return (new cMateriales()).Listar_CatalogoMaterialesFC(D_FechaIEmision, D_FechaFEmision, UserName);
        }

        [WebMethod(Description = "CONSUMO DE MATERIALES POR CENTRO DE COSTOS")]
        public DataTable Listar_VM_CC(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new cMateriales()).Listar_VM_CC(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "MOVIMIENTO DE MATERIALES")]
        public DataTable Listar_MoviMatIOCVSMVD(string Centro_Operativo, string FECHA_INICIAL_MOVIMIENTO,
            string FECHA_FINAL_MOVIMIENTO, string CODIGO_MATERIAL, string UserName)
        {
            return (new cMateriales()).Listar_MoviMatIOCVSMVD(Centro_Operativo, FECHA_INICIAL_MOVIMIENTO,
                FECHA_FINAL_MOVIMIENTO, CODIGO_MATERIAL, UserName);
        }

        [WebMethod(Description = "MOVIMIENTO DE MATERIALES POR CORTE DE INVENTARIO")]
        public DataTable Listar_MoviMaterialAud(string Almacen, string año_Inventario, string Corte,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return (new cMateriales()).Listar_MoviMaterialAud(Almacen, año_Inventario, Corte, Fecha_Inicial,
                Fecha_Final, UserName);
        }

        [WebMethod(Description = "CALCULO CANTIDAD EQUIVALENTE DE UN MATERIAL CON DIMENSIONES")]
        public DataTable Listar_EQUIVA2013(string V_MATERIAL, string V_DIMLARGO, string V_DIMANCHO, string V_UNMEDIDA,
            string V_CANTREQ, string UserName)
        {
            return (new cMateriales()).Listar_EQUIVA2013(V_MATERIAL, V_DIMLARGO, V_DIMANCHO, V_UNMEDIDA, V_CANTREQ,
                UserName);
        }

        [WebMethod(Description = "CONSUMO DE MATERIALES POR CENTRO DE COSTOS")]
        public DataTable Listar_VM_CC_ESPECIFICO(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new cMateriales()).Listar_VM_CC_ESPECIFICO(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "RESERVAS DE MATERIALES -OTS PRODUCCION")]
        public DataTable Listar_ControlReservaMat(string V_CODIGO_MATERIAL, string D_FECHA_RESERVA_inicial,
            string D_FECHA_RESERVA_final, string UserName)
        {
            return (new cMateriales()).Listar_ControlReservaMat(V_CODIGO_MATERIAL, D_FECHA_RESERVA_inicial,
                D_FECHA_RESERVA_final, UserName);
        }

        [WebMethod(Description = "Saldo de almacén")]
        public DataTable Listar_SaldoAlmacen(string Material_Inicial, string Material_Final, string UserName)
        {
            return (new cMateriales()).Listar_SaldoAlmacen(Material_Inicial, Material_Final, UserName);
        }

        [WebMethod(Description = "Salidas de material  que provienen de las: OS/Rend.Cta./Fondos Fijos, de cada centro de costos en un rango de fechas")]
        public DataTable Listar_AtencionMaterialesCC(string V_Centro_Operativo, string D_Fecha_Inicio,
            string D_Fecha_Termino, string V_CC, string UserName)
        {
            return (new cMateriales()).Listar_AtencionMaterialesCC(V_Centro_Operativo, D_Fecha_Inicio,
                D_Fecha_Termino, V_CC, UserName);
        }

        [WebMethod(Description = "Muestra el consumo de Vales de Salida de Material  por Tipo de V/M {OTS o CIN}")]
        public DataTable Listar_CONSUMO_VM_VALJDE(string V_TIPO_VALE, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return (new cMateriales()).Listar_CONSUMO_VM_VALJDE(V_TIPO_VALE, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "SEGUIMIENTO DE ATENCION DE REQUERIMIENTOS POR OTS")]
        public DataTable Listar_SeguiRequeDeta_OTS(string Codigo_Division, string Codigo_OT,
            string FECHA_EMISION_OT_Inicio, string FECHA_EMISION_OT_Termino, string FECHA_ATENCION_INICIO,
            string FECHA_ATENCION_TERMINO, string UserName)
        {
            return (new cMateriales()).Listar_SeguiRequeDeta_OTS(Codigo_Division, Codigo_OT, FECHA_EMISION_OT_Inicio,
                FECHA_EMISION_OT_Termino, FECHA_ATENCION_INICIO, FECHA_ATENCION_TERMINO, UserName);
        }

        [WebMethod(Description = "PRECIOS DE REPOSICION A LA FECHA")]
        public DataTable Listar_PRECIOSREPOSICION(string CLAS_MATERIAL, string UserName)
        {
            return (new cMateriales()).Listar_PRECIOSREPOSICION(CLAS_MATERIAL, UserName);
        }

        [WebMethod(Description = "punto de repedido por stock disponible (gravado/exonerado) con un indicador de materiales criticos")]
        public DataTable Listar_Punto_Reposicion(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return (new cMateriales()).Listar_Punto_Reposicion(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        [WebMethod(Description = "Punto de Reposición por Stock, precios promedios gravado y exonerado")]
        public DataTable Listar_Punto_Repo_Precios_Prome(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return (new cMateriales()).Listar_Punto_Repo_Precios_Prome(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        [WebMethod(Description = "Pedidos de Materiales - MULTIPROPOSITO")]
        public DataTable Listar_PedidoMateMultipropo(string NUMERO_PEDIDO, string EMISION_INICIAL_PEDIDO,
            string EMISION_FINAL_PEDIDO, string CODIGO_MATERIAL, string CODIGO_AUXILIAR, string UserName)
        {
            return (new cMateriales()).Listar_PedidoMateMultipropo(NUMERO_PEDIDO, EMISION_INICIAL_PEDIDO,
                EMISION_FINAL_PEDIDO, CODIGO_MATERIAL, CODIGO_AUXILIAR, UserName);
        }

        [WebMethod(Description = "Reservas Pendientes ( OTs PRODUCCION )")]
        public DataTable Listar_Reserva_OT_Produccion(string Codigo_OT, string Codigo_Material, string Estado_OT,
            string Estado_Seguimiento_OT, string UserName)
        {
            return (new cMateriales()).Listar_Reserva_OT_Produccion(Codigo_OT, Codigo_Material, Estado_OT,
                Estado_Seguimiento_OT, UserName);
        }

        [WebMethod(Description = "MATERIALES - CARGA MASIVA ")]
        public DataTable Listar_MAT_MASIVA(string CLASE_SUBCLASE, string UserName)
        {
            return (new cMateriales()).Listar_MAT_MASIVA(CLASE_SUBCLASE, UserName);
        }

        [WebMethod(Description = "Reservas de Materiales de Areas Usuarias y OT's Internas (SE/PC)")]
        public DataTable Listar_ReserMateAreasUsua(string Area_Usuaria, string división, string Material, string OT,
            string UserName)
        {
            return (new cMateriales()).Listar_ReserMateAreasUsua(Area_Usuaria, división, Material, OT, UserName);
        }

        [WebMethod(Description = "Muestra el catalogo CUBSO por su clase, la cual esta en los dos primeros digitos del codigo del material")]
        public DataTable Listar_CODIFICACION_CUBSO(string CLASE, string UserName)
        {
            return (new cMateriales()).Listar_CODIFICACION_CUBSO(CLASE, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS GENERADAS POR PAQUETES - DETALLE DEL PAQUETE")]
        public DataTable Listar_PedidoMaterialCompraOTS(string DIVISION, string NRO_PEDIDO, string UserName)
        {
            return (new cMateriales()).Listar_PedidoMaterialCompraOTS(DIVISION, NRO_PEDIDO, UserName);
        }

        [WebMethod(Description = "Materiales  Con o sin stock por Centro Operativo")]
        public DataTable Listar_MatlesSinMov_PDR8701(string Centro_Operativo, string Almacen, string Fecha_Inicial,
            string Fecha_Final, string Clase, string Stock, string UserName)
        {
            return (new cMateriales()).Listar_MatlesSinMov_PDR8701(Centro_Operativo, Almacen, Fecha_Inicial,
                Fecha_Final, Clase, Stock, UserName);
        }

        [WebMethod(Description = "Muestra la entrada y salida de materiales del centro operativo Sima Callao, en un rango de fechas")]
        public DataTable Listar_controlmateriales(string N_OPC, string N_CEO, string D_FECHAINI, string D_FECHAFIN, string C_DESTINO_OPER, string V_COD_CLASE_MAT, string UserName)
        {
            return (new cMateriales()).Listar_controlmateriales(N_OPC, N_CEO, D_FECHAINI, D_FECHAFIN, C_DESTINO_OPER, V_COD_CLASE_MAT, UserName);
        }

        [WebMethod(Description = "SALDOS HISTORICOS DE MATERIALES EN EL ALMACEN (CIERRE)")]
        public DataTable Listar_saldo_historico_mat(string CENTRO_OPERATIVO, string FECHA_DE_PROCESO, string MATERIAL,
            string UserName)
        {
            return (new cMateriales()).Listar_saldo_historico_mat(CENTRO_OPERATIVO, FECHA_DE_PROCESO, MATERIAL,
                UserName);
        }

        [WebMethod(Description = "GASTOS DIRECTOS POR OT'S POR PROYECTOS (MATERIALES), mediante Un Reporte elaborados para el PCI")]
        public DataTable Listar_DET_G_PRY_OT_VSM_PCI(string Centro_Operativo, string Division, string Proyecto, string Fecha_Emision, string UserName)
        {
            return (new cMateriales()).Listar_DET_G_PRY_OT_VSM_PCI(Centro_Operativo, Division, Proyecto, Fecha_Emision, UserName);
        }

        [WebMethod(Description = "Lista los Recursos del Vales de Salida de Material  por Tipo CEO, Nro Vale ó Cód. Almacen ó  Cod. Área Usuaria")]
        public DataTable Listar_Vale_Salida_Mat(string s_CEO, string s_NRO_VALE, string s_COD_ALMA, string s_AREA_USU,
              string UserName)
        {
            return (new cMateriales()).Listar_Vale_Salida_Mat(s_CEO, s_NRO_VALE, s_COD_ALMA, s_AREA_USU,
               UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: STOCK

        [WebMethod(Description = "El detalle de las Transferidas de stock")]
        public DataTable Listar_TransStockVerFec(string FECHA_DE_TRANSFERENCIA_Inicio,
            string FECHA_DE_TRANSFERENCIA_Termino, string Material_Inicial, string Material_Final, string UserName)
        {
            return (new cStock()).Listar_TransStockVerFec(FECHA_DE_TRANSFERENCIA_Inicio,
                FECHA_DE_TRANSFERENCIA_Termino, Material_Inicial, Material_Final, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_TransStockVerCon(string Fecha_Inicial, string Fecha_Final, string USUARIO,
            string TERMINAL, string UserName)
        {
            return (new cStock()).Lista_TransStockVerCon(Fecha_Inicial, Fecha_Final, USUARIO, TERMINAL, UserName);
        }

        [WebMethod(Description = "DISPONIBILIDAD DE STOCK COMPRADO")]
        public DataTable Listar_Valorizacion_Disp_Stock(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new cStock()).Listar_Valorizacion_Disp_Stock(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Punto de Reposición por Stock (Control), por una lista diaria de los materiales de reposicion de stock gravado y exonerado cuyo stock disponible es menor o igual al stock de repedido")]
        public DataTable Listar_Punto_Reposicion_Pedido(string TIPO_STOCK, string CLASE_MATERIAL, string CLASIFICACION,
            string MATERIAL_CRITICO, string UserName)
        {
            return (new cStock()).Listar_Punto_Reposicion_Pedido(TIPO_STOCK, CLASE_MATERIAL, CLASIFICACION,
                MATERIAL_CRITICO, UserName);
        }

        [WebMethod(Description = "Liberacion de reservas,  incluye consumo  a partir de la fecha minima de liberacion.")]
        public DataTable Listar_liberareservascon(string FECHA_FINAL, string FECHA_INICIAL, string UserName)
        {
            return (new cStock()).Listar_liberareservascon(FECHA_FINAL, FECHA_INICIAL, UserName);
        }

        [WebMethod(Description = "Transferidas de stock por Liberaciones de Reservas incluye consumo a partir de la fecha minima de liberacion")]
        public DataTable Listar_liberareservastrf(string FECHA_DE_LIBERACION_INICIO, string FECHA_DE_LIBERACION_TERMINO,
            string MATERIAL_FINAL, string MATERIAL_INICIAL, string UserName)
        {
            return (new cStock()).Listar_liberareservastrf(FECHA_DE_LIBERACION_INICIO, FECHA_DE_LIBERACION_TERMINO,
                MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        [WebMethod(Description = "67. InventarioFisico - Resultado de Inventario")]
        public DataTable Listar_InventarioFisicoResultado(string V_CEO, string N_ANIO, string V_CODALM, string V_CODCOR, string V_DIFE, string UserName)
        {
            return (new cStock()).Listar_InventarioFisicoResultado(V_CEO, N_ANIO, V_CODALM, V_CODCOR, V_DIFE, UserName);
        }

        [WebMethod(Description = "68. InventarioFisico - Toma de Inventario")]
        public DataTable Listar_InventarioFisicoToma(string CEO_OPE, string V_ANO_INV, string V_COD_ALM, string V_COD_COR, string DIFE, string UserName)
        {
            return (new cStock()).Listar_InventarioFisicoToma(CEO_OPE, V_ANO_INV, V_COD_ALM, V_COD_COR, DIFE, UserName);
        }

        [WebMethod(Description = "01.CargaMaterialesPaquetes_CO")]
        public DataTable Listar_Paquetes_Materiales(string PAQUETE, string UserName)
        {
            return (new cStock()).Listar_Paquetes_Materiales(PAQUETE, UserName);
        }

        [WebMethod(Description = "1. Ingresos al Almacen")]
        public string Listar_IngresosAlmacen(string V_CEO, string D_FECHAINI, string D_FECHAFIN, string V_CODALM, string V_CODMAT, string UserName)
        {
            try
            {
                DataTable dt = (new cStock()).Listar_IngresosAlmacen(V_CEO, D_FECHAINI, D_FECHAFIN, V_CODALM, V_CODMAT, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_IngresosAlmacen";

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

        [WebMethod(Description = "3. Control de Materiales - Total Movimiento x rango de fechas")]
        public DataTable Listar_Ctrolmaterial_consol(string N_CEO, string N_CODMAT, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cStock()).Listar_Ctrolmaterial_consol(N_CEO, N_CODMAT, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "4. Control de Materiales - Total Movimiento Diario")]
        public DataTable Listar_ControlMatTotalxDia(string V_Centro_Operativo, string D_Fecha_Movimiento_Inicial, string D_Fecha_Movimiento_Final, string V_Codigo_Clase_Material, string UserName)
        {
            return (new cStock()).Listar_ControlMatTotalxDia(V_Centro_Operativo, D_Fecha_Movimiento_Inicial, D_Fecha_Movimiento_Final, V_Codigo_Clase_Material, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: PROVEEDORES

        [WebMethod(Description = "Archivo 4ta")]
        public DataTable Listar_PDT601_4TA(string D_FECHAPRO, string UserName)
        {
            return (new cProveedores()).Listar_PDT601_4TA(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "Pdt0601 Extension Ps4")]
        public DataTable Listar_PDT601_PS4(string D_FECHAPRO, string UserName)
        {
            return (new cProveedores()).Listar_PDT601_PS4(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "RETENCIONES DE 4TA. CATEGORIA - SIMA-CALLAO")]
        public DataTable Listar_Reg_Retencion_4TA(string D_FECHAPRO, string UserName)
        {
            return (new cProveedores()).Listar_Reg_Retencion_4TA(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "DEVOLUCION A PROVEEDORES (SALIDAS DE ALMACEN)")]
        public DataTable Listar_Salidas_Dev_Prov(string N_CEO, string V_PROCESO, string UserName)
        {
            return (new cProveedores()).Listar_Salidas_Dev_Prov(N_CEO, V_PROCESO, UserName);
        }

        [WebMethod(Description = "PROGRAMA DE ADQUISICION PARA ENVIO DE COTIZACION AL PROVEEDOR")]
        public DataTable Listar_ProgramaAdquiEnvioCot(string PROGRAMA_ADQUISICION, string UserName)
        {
            return (new cProveedores()).Listar_ProgramaAdquiEnvioCot(PROGRAMA_ADQUISICION, UserName);
        }

        [WebMethod(Description = "Registro de Proveedores")]
        public DataTable Listar_RegistroProveedores(string Fecha_Registro, string Estado, string Tipo, string RUC,
            string Procedencia, string UserName)
        {
            return (new cProveedores()).Listar_RegistroProveedores(Fecha_Registro, Estado, Tipo, RUC, Procedencia,
                UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: BIENES

        [WebMethod(Description = "los bienes almacenados")]
        public DataTable Listar_BienesAlmacenados(string V_CLASE_MATERIAL, string D_FECHA_ALMACENAMIENTO_inicial,
            string D_FECHA_ALMACENAMIENTO_fina, string UserName)
        {
            return (new cBienes()).Listar_BienesAlmacenados(V_CLASE_MATERIAL, D_FECHA_ALMACENAMIENTO_inicial,
                D_FECHA_ALMACENAMIENTO_fina, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: REQUERIMIENTOS

        [WebMethod(Description = "Presupuesto (cantidades de recursos Requeridos segun nro de cta contable)")]
        public DataTable Listar_Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {

            return (new cRequerimientos()).Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);

        }

        [WebMethod(Description = "Presupuesto2 (cantidades de recursos Requeridos segun nro de cta contable) en string xml")]
        public string LISTAR_PRESUPUESTO2(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            try
            {
                DataTable dt = (new cRequerimientos()).Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Presupuesto";

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

        #endregion

        #region Procedimientos almacenados de clasificacion: SERVICIOS

        [WebMethod(Description = "Muestra el Catalogo General de Servicios SR ")]
        public DataTable Listar_Catalogo_Servicios_SR(string CLASE, string UserName)
        {
            return (new cServicios()).Listar_Catalogo_Servicios_SR(CLASE, UserName);
        }

        [WebMethod(Description = "GASTOS DIRECTOS POR OT'S POR PROYECTOS (SERVICIOS), mediante Un Reporte elaborados para el PCI")]
        public DataTable Listar_DET_G_PRY_OT_SER_PCI(string Centro_Operativo, string Division, string Proyecto, string UserName)
        {
            return (new cServicios()).Listar_DET_G_PRY_OT_SER_PCI(Centro_Operativo, Division, Proyecto, UserName);
        }

        [WebMethod(Description = "GASTOS DIRECTOS POR OT'S POR PROYECTOS (SERVICIOS) V.2, mediante Un Reporte elaborados para el PCI")]
        public string Listar_DET_G_PRY_OT_SER_PCI2(string Centro_Operativo, string Division, string Proyecto, string UserName)
        {
            try
            {
                DataTable dt = (new cServicios()).Listar_DET_G_PRY_OT_SER_PCI(Centro_Operativo, Division, Proyecto, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_DET_GASTO_PRY_OT_SER_PCI";

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

        [WebMethod(Description = "ORDENES DE SERVICIO - DETALLE DE OTS POR RANGO DE FECHAS")]
        public DataTable Listar_OS_DETALLE_OTS(string s_fecha_ini, string s_fecha_fin, string UserName)
        {
            return (new cServicios()).Listar_OS_DETALLE_OTS(s_fecha_ini, s_fecha_fin, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: PROYECTOS

        [WebMethod(Description = "RESUMEN DE PAGOS (nro documento) POR PROYECTOS")]
        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            return (new cProyectos()).Listar_PRY_PAG_TOT(Centro_Operativo, división, Proyecto, Nro_Orden, Procedencia,
                Tipo_Orden, UserName);
        }

        #endregion

        #region Procedimeintos almacenados de clasificacion: ALMACEN

        [WebMethod(Description = "5. OC Locales - Montos AlmFac")]
        public DataTable Listar_OC_Locales_Montos_AlmFac(string V_CEO, string V_OC, string UserName)
        {
            return (new cAlmacen()).Listar_OC_Locales_Montos_AlmFac(V_CEO, V_OC, UserName);
        }

        [WebMethod(Description = "6.Saldo Valorizado Historico - Detalle")]
        public string Listar_SALDO_HIST_ALMACEN_DETALLE(string Centro_Operativo, string Fecha_de_Proceso,
            string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_SALDO_HIST_ALMACEN_DETALLE(Centro_Operativo, Fecha_de_Proceso, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_SALDO_HIST_ALMACEN_DETALLE";

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

        [WebMethod(Description = "9.Kardex Exonerado UNIDADES FISICAS")]
        public string Listar_KARDEX_UF_EXONERADO(string V_MES, string V_ANIO, string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_KARDEX_UF_EXONERADO(V_MES, V_ANIO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_KARDEX_UF_EXONERADO";

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
        [WebMethod(Description = "10.Kardex Gravado UNIDADES FISICAS")]
        public string Listar_KARDEX_UF_GRAVADO(string D_Periodo_Saldo, string D_Mes_Periodo, string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_KARDEX_UF_GRAVADO(D_Periodo_Saldo, D_Mes_Periodo, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_KARDEX_UF_GRAVADO";

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
        [WebMethod(Description = "11. Control de Materiales - OC almacenadas")]
        public DataTable Listar_CTRL_MAT_ALM_OCO(string Fec_inic, string Fec_Final, string Codigo_OT, string UserName)
        {
            return (new cAlmacen()).Listar_CTRL_MAT_ALM_OCO(Fec_inic, Fec_Final, Codigo_OT, UserName);
        }
        [WebMethod(Description = "7.Saldo Valorizado Historico - Resumen")]
        public string Listar_SALDO_HIST_ALMACEN_RESUMEN(string Centro_Operativo, string Fecha_de_Proceso, string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_SALDO_HIST_ALMACEN_RESUMEN(Centro_Operativo, Fecha_de_Proceso, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_SALDO_HIST_ALMACEN_RESUMEN";

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
        [WebMethod(Description = "12. Control de Materiales - Detalle Movimiento (sin formato de presentacion)")]
        public DataTable Listar_CTRLMATERIAL_SINFORMAT(string N_CEO, string N_CODMAT, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new cAlmacen()).Listar_CTRLMATERIAL_SINFORMAT(N_CEO, N_CODMAT, D_FECHAINI, D_FECHAFIN, UserName);
        }
        //---------------
        [WebMethod(Description = "12. Control de Materiales - Detalle Movimiento (sin formato de presentacion)")]
        public DataTable Listar_SALDO_ALMACEN_DETALLE(string Centro_Operativo, string Codigo_Clase_Material, string UserName)
        {
            return (new cAlmacen()).Listar_SALDO_ALMACEN_DETALLE(Centro_Operativo, Codigo_Clase_Material, UserName);
        }

        [WebMethod(Description = "12. Control de Materiales - Detalle Movimiento (sin formato de presentacion VERS. 2)")]
        public string Listar_SALDO_ALMACEN_DETALLE2(string Centro_Operativo, string Codigo_Clase_Material, string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_SALDO_ALMACEN_DETALLE(Centro_Operativo, Codigo_Clase_Material, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_ALM_OCO_ATE_RSV";

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

        [WebMethod(Description = "14. Saldo Valorizado - Resumen")]
        public DataTable Listar_SALDO_ALMACEN_RESUMEN(string Centro_Operativo, string Codigo_Clase, string UserName)
        {
            return (new cAlmacen()).Listar_SALDO_ALMACEN_RESUMEN(Centro_Operativo, Codigo_Clase, UserName);
        }
        [WebMethod(Description = "15. Ordenes de Compras paquetes - Guias")]
        public DataTable Listar_OcoImpGuias_v1(string ORDEN_COMPRA, string NUMERO_GUIA, string UserName)
        {
            return (new cAlmacen()).Listar_OcoImpGuias_v1(ORDEN_COMPRA, NUMERO_GUIA, UserName);
        }
        [WebMethod(Description = "16. Salidas para Proveedores paquetes")]
        public DataTable Listar_SALIDAS_DEV_PROV_EMB_V1(string Fecha_Guia, string UserName)
        {
            return (new cAlmacen()).Listar_SALIDAS_DEV_PROV_EMB_V1(Fecha_Guia, UserName);
        }
        [WebMethod(Description = "17. Vales de Devolución paquetes")]
        public string Listar_Vales_Dev_Pqt(string v_CEO, string V_PERIODO, string V_Estado_VDE, string V_Numero_VDE, string UserName)
        {
            try
            {
                DataTable dt = (new cAlmacen()).Listar_Vales_Dev_Pqt(v_CEO, V_PERIODO, V_Estado_VDE, V_Numero_VDE, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_VALES_DEV_PQT";

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

        [WebMethod(Description = "8.Saldos Cierre Almacen y Balance - Diferencias")]
        public DataTable Listar_SaldosAlmacenBalance_Dif(string V_AÑO, string V_MES, string UserName)
        {
            return (new cAlmacen()).Listar_SaldosAlmacenBalance_Dif(V_AÑO, V_MES, UserName);
        }
        #endregion

    }
}
