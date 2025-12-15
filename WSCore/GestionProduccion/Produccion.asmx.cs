using Controladora.GestionProduccion;
using EntidadNegocio.GestionProduccion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Xml;
using CActividad = Controladora.GestionProduccion.CActividad;

namespace WSCore.GestionProduccion
{
    /// <summary>
    /// Descripción breve de Produccion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Produccion : System.Web.Services.WebService
    {
        readonly string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];
        string sMensaje = "";

        #region Metodos_Transaccionales_Actividades

        [WebMethod(Description = "Actualiza Descripción de una Actividad de una OT")]
        public string Modifica_Actividad_Desc(int iCodigoOT, string sCodigoDiv, string sCodigoActiv,
            int iNroCrv, string sUserReg, string sCodigoTll, string sDescrip, string sUsuario)
        {
            try
            {

                ActividadBE oActividadBE = new ActividadBE();
                oActividadBE.ambiente = sAmbiente;
                oActividadBE.CodigoOT = iCodigoOT;
                oActividadBE.CodigoDiv = sCodigoDiv;
                oActividadBE.CodigoActiv = sCodigoActiv;
                oActividadBE.NroCrv = iNroCrv;
                oActividadBE.UserReg = sUserReg;
                oActividadBE.CodigoTll = sCodigoTll;
                oActividadBE.DescripcionD = sDescrip;
                oActividadBE.UserName = sUsuario;
                return (new CActividad()).Modifica(oActividadBE);
            }
            catch (Exception ex)
            {
                return "-1";

            }
        }

        [WebMethod(Description = "Actualiza el Código de una Actividad de una OT")]
        public string Modifica_cod_atv(string iCodCEO, int iCodigoOT, string sCodigoDiv, string sCodigoActiv,
            int iNroCrv, string sUserReg, string sNewCodAtv, int iNewCrvAtv, string sUsuario)
        {
            try
            {

                ActividadBE oActividadBE = new ActividadBE();
                oActividadBE.ambiente = sAmbiente;
                oActividadBE.CodigoCEO = iCodCEO;
                oActividadBE.CodigoOT = iCodigoOT;
                oActividadBE.CodigoDiv = sCodigoDiv;
                oActividadBE.CodigoActiv = sCodigoActiv;
                oActividadBE.NroCrv = iNroCrv;
                oActividadBE.UserReg = sUserReg;
                oActividadBE.CodigoTll = sNewCodAtv;   // se reutilizará para pasar el nuevo código de la actividad
                oActividadBE.NroVal = iNewCrvAtv;     // se reutilizará para pasar el nuevo correlativo de la actividad
                oActividadBE.UserName = sUsuario;
                return (new CActividad()).Modifica_cod_atv(oActividadBE);
            }
            catch (Exception ex)
            {
                return "-1";

            }
        }

        #endregion

        #region Metodos Transacionales Ordenes Trabajo

        [WebMethod(Description = "Actualiza Descripción de la Orden de Trabajo")]
        public string Modifica_OT_Desc(int iCodigoOT, string sCodigoDiv, string sDescrip,
            string sUserReg, string sUsuario)
        {
            try
            {

                OtBE oOtBE = new OtBE();
                oOtBE.ambiente = sAmbiente; // ambiente de conexion
                oOtBE.CodigoOT = iCodigoOT;
                oOtBE.CodigoDiv = sCodigoDiv;
                oOtBE.DescripcionD = sDescrip;
                oOtBE.UserReg = sUserReg; // usuario que solicita el cambio
                oOtBE.UserName = sUsuario; // usuario de OTIC que realizar el cambio
                return (new COt()).Modifica(oOtBE);
            }
            catch (Exception ex)
            {
                return "-1";

            }
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: General

        [WebMethod(Description = " Tarifas maquinarias")]
        public DataTable Listar_tarifa_maq(string V_TALLER, string UserName)
        {
            return (new CGeneral()).Listar_tarifa_maq(V_TALLER, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Materiales

        [WebMethod(Description = "15. Lista De Materiales")]
        public DataTable Listar_lista_materiales(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new CMateriales()).Listar_Lista_Materiales(V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Lista De Materiales de una valorización (test)")]
        public DataTable Listar_materiales_test(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new CMateriales()).Listar_materiales_test(V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "3. Saldo Valorizado por Clase de Material. Saldo Valorizado por Clase de Material")]
        public DataTable Listar_Saldo_Valorizado_Material(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            return (new CMateriales()).Listar_Saldo_Valorizado_Material(N_CEO, V_ANIO, V_MES, UserName);
        }

        [WebMethod(Description = "1. Resumen x OT - Comparativo de Venta vs. Costo x Proyecto. Resumen x OT - Comparativo de Venta vs. Costo x Proyecto")]
        public DataTable Listar_ComparVentvsCostoProyecotR(string V_Centro_Operativo, string V_Division,
            string V_Periodo, string V_Proyecto, string UserName)
        {
            return (new CMateriales()).Listar_ComparVentvsCostoProyecotR(V_Centro_Operativo, V_Division, V_Periodo,
                V_Proyecto, UserName);
        }

        [WebMethod(Description = "2. Detalle x OT - Comparativo de Venta vs. Costo x Proyecto. Detalle x OT - Comparativo de Venta vs. Costo x Proyecto")]
        public DataTable Listar_ComparVentvsCostoProyec_ot(string V_Centro_Operativo, string V_Division,
            string V_Periodo, string V_Proyecto, string UserName)
        {
            return (new CMateriales()).Listar_ComparVentvsCostoProyec_ot(V_Centro_Operativo, V_Division, V_Periodo,
                V_Proyecto, UserName);
        }

        [WebMethod(Description = "02. OTS por Proyecto. OTS por Proyecto")]
        public DataTable Listar_OTS_por_Proyecto(string V_Centro_Operativo, string V_Division, string V_Proyecto,
            string UserName)
        {
            return (new CMateriales()).Listar_OTS_por_Proyecto(V_Centro_Operativo, V_Division, V_Proyecto, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Mob

        [WebMethod(Description = "Vacaciones - Mano de obra directa e indirecta")]
        public DataTable Listar_vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            return (new CMob()).Listar_vacaciones(D_PERIODO, V_CO, V_ROL, UserName);
        }

        [WebMethod(Description = "Novedades de planilla")]
        public DataTable Listar_novedades_paus(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            return (new CMob()).Listar_novedades_paus(N_CEO, V_CODUNS, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Mano de obra -  version string xml")]
        public string Listar_mob_x_fecha2(string D_FECHAINI, string D_FECHAFIN, string N_CEO, string UserName)
        {
            try
            {
                DataTable dt = (new CMob()).Listar_mob_x_fecha(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);

                if (dt != null)
                {
                    DataTable dtCopy = dt.Copy();
                    dtCopy.TableName = "SP_MOB_X_FECHA";

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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Mano de obra en JSON Streaming")]
        public void Listar_mob_x_fecha_json_stream(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            HttpContext context = HttpContext.Current;

            context.Response.BufferOutput = false;
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";

            context.Server.ScriptTimeout = 1800;

            IDataReader reader = null;

            try
            {
                reader = (new CMob()).Listar_mob_x_fecha_reader(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);

                context.Response.Write("{\"success\": true, \"data\": [");
                context.Response.Flush();

                bool first = true;

                while (reader.Read())
                {
                    if (!context.Response.IsClientConnected)
                        return;

                    if (!first)
                        context.Response.Write(",");

                    first = false;

                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);

                    string json = JsonConvert.SerializeObject(row);
                    context.Response.Write(json);

                    context.Response.Flush();
                }

                context.Response.Write("]}");
                context.Response.Flush();
            }
            catch (HttpException httpEx)
            {
                if (!context.Response.IsClientConnected)
                    return;

                context.Response.Write("{\"success\": false, \"error\": \"Cliente desconectado\"}");
            }
            catch (Exception ex)
            {
                if (!context.Response.IsClientConnected)
                    return;

                context.Response.Write(JsonConvert.SerializeObject(new
                {
                    success = false,
                    errorMessage = ex.Message
                }));
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        [WebMethod(Description = "Mano de obra en JSON completo")]
        public string Listar_mob_x_fecha_json(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            IDataReader reader = null;

            try
            {
                reader = (new CMob()).Listar_mob_x_fecha_reader(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);

                var rows = new List<Dictionary<string, object>>();

                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);

                    rows.Add(row);
                }

                var result = new
                {
                    success = true,
                    data = rows
                };

                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                var error = new
                {
                    success = false,
                    errorMessage = ex.Message
                };
                return JsonConvert.SerializeObject(error);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        [WebMethod(Description = "Mano de obra")]
        public DataTable Listar_mob_x_fecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return (new CMob()).Listar_mob_x_fecha(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }

        [WebMethod(Description = "Mano de obra -  version string xml")]
        public string Listar_mob_x_fecha_xProy2(string N_CEO, string V_PROYECTO, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            try
            {
                DataTable dt = (new CMob()).Listar_mob_x_fecha_xProy2(N_CEO, V_PROYECTO, D_FECHAINI, D_FECHAFIN, UserName);

                if (dt != null)
                {
                    DataTable dtCopy = dt.Copy();
                    dtCopy.TableName = "SP_Mob_X_Fecha_X_Proy";

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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Saldos de Mano de Obra")]
        public DataTable Listar_lista_saldo_mo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return (new CMob()).Listar_lista_saldo_mo(N_CEO, V_CATVCRV, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "4.-detalle_mob. Listado de Mano de Obra Consumida por Taller con el 1.5")]
        public DataTable Listar_detalle_mob(string V_CO, string V_DIVISION, string V_OT, string d_fechaini,
            string d_fecha_fin, string UserName)
        {
            return (new CMob()).Listar_detalle_mob(V_CO, V_DIVISION, V_OT, d_fechaini, d_fecha_fin, UserName);
        }

        [WebMethod(Description = "4.mob. Listado deMano de Obra Consumida por Taller con el 1.5, Modalidad de trabajo  Sobretiempo que ha sido pagado")]
        public DataTable Listar_mob(string D_AÑO, string D_MESINI, string D_MESFIN, string UserName)
        {
            return (new CMob()).Listar_mob(D_AÑO, D_MESINI, D_MESFIN, UserName);
        }

        [WebMethod(Description = "2.Lista_mob_pago. UTILIZACION DE MOB EN TALLERES")]
        public DataTable Listar_Lista_mob_pago(string V_rol, string V_tiphex, string V_CentroCostoDesde,
            string V_CentroCostoHasta, string UserName)
        {
            return (new CMob()).Listar_Lista_mob_pago(V_rol, V_tiphex, V_CentroCostoDesde, V_CentroCostoHasta,
                UserName);
        }

        [WebMethod(Description = "2.Lista_mob_pago. UTILIZACION DE MOB EN TALLERES vers2")]
        public string Listar_Lista_mob_pago2(string V_rol, string V_tiphex, string V_CentroCostoDesde,
                                           string V_CentroCostoHasta, string UserName)
        {
            try
            {
                DataTable dt = (new CMob()).Listar_Lista_mob_pago2(V_rol, V_tiphex, V_CentroCostoDesde, V_CentroCostoHasta,
                UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Lista_mob_pago";

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

        [WebMethod(Description = "3.Res_Lista_mob_pago. UTILIZACION DE MOB X CIERRE Y TIPO")]
        public DataTable Listar_Res_Lista_mob_pago(string V_tiphex, string UserName)
        {
            return (new CMob()).Listar_Res_Lista_mob_pago(V_tiphex, UserName);
        }

        [WebMethod(Description = "3. Mano Obra x OT  Fecha. Mano Obra x OT  Fecha - R03")]
        public DataTable Listar_MobXFechaOt(string v_Centro_Operativo, string v_Division, string v_OT, string UserName)
        {
            return (new CMob()).Listar_MobXFechaOt(v_Centro_Operativo, v_Division, v_OT, UserName);
        }

        [WebMethod(Description = "2.-Proyecto Utilización MOB - SUBMARINOS")]
        public DataTable Listar_DETALLE_GASTO_PRY_OT_MOBSU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new CMob()).Listar_DETALLE_GASTO_PRY_OT_MOBSU(N_CEO, V_CODDIV, V_CODPRY, D_FECHAINI, D_FECHAFIN, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Ordenes

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_detalle_gasto_pry_ot_oses(string N_CEO, string V_CODDIV, string V_CODPRY, string V_NROOTS, string UserName)
        {
            return (new COrdenes()).Listar_detalle_gasto_pry_ot_oses(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_det_gasto_pry_ot_ocosu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_NROOTS, string V_PROYECTO, string V_ANIO, string UserName)
        {
            return (new COrdenes()).Listar_det_gasto_pry_ot_ocosu(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_NROOTS, V_PROYECTO, V_ANIO, UserName);
        }

        [WebMethod(Description = "Ordenes de compra OTS")]
        public DataTable Listar_ot_ocompra(string D_FECHA_INICIO, string D_FECHA_FIN, string V_DIVISION, string UserName)
        {
            return (new COrdenes()).Listar_ot_ocompra(D_FECHA_INICIO, D_FECHA_FIN, V_DIVISION, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Ot

        [WebMethod(Description = "RELACION DE OT'S POR PROYECTOS ACTIVOS")]
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string sAnio, string UserName)
        {
            return (new COt()).Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, sAnio, UserName);
        }

        [WebMethod(Description = "FACTURACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new COt()).Listar_detalle_gasto_pry_ot_fac(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Ots con Facturas")]
        public DataTable Listar_lista_ots_dq(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            return (new COt()).Listar_lista_ots_dq(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  DE CABERECA  DE LA OT")]
        public DataTable Listar_cabecera_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_cabecera_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
        }

        [WebMethod(Description = "INFORMACION DE ACTIVIDADES DE LAS OT'S x OT")]
        public DataTable Listar_actividad_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_actividad_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
        }

        [WebMethod(Description = "INFORMACION DE ACTIVIDADES DE LAS OT'S x OT por ambiente conexión")]
        public DataTable Listar2_actividad_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            try
            {
                return (new COt()).Listar2_actividad_ot(N_CEO, V_CODDIV, V_NROOTS, sAmbiente, UserName);
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Gastos Directos de Ots por fecha de utilizacion")]
        public DataTable Listar_lista_estado_ot(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODSTD, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_lista_estado_ot(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODSTD, V_NROOTS, UserName);
        }

        [WebMethod(Description = "1 Proyecto OT's  (submarinos)")]
        public DataTable Listar_det_gasto_pry_ot_sin_factsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new COt()).Listar_det_gasto_pry_ot_sin_factsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "10 FACTURACION DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_det_gasto_pry_ot_facsu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_PROYECTO, string UserName)
        {
            return (new COt()).Listar_det_gasto_pry_ot_facsu(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  OT'S X FECHA")]
        public DataTable Listar_actividades_jg(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string UserName)
        {
            return (new COt()).Listar_actividades_jg(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  OT'S X FECHA")]
        public DataTable Listar_actividades_jg2(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string V_CODTLLR, string UserName)
        {
            return (new COt()).Listar_actividades_jg2(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, V_CODTLLR, UserName);
        }

        [WebMethod(Description = "Gastos Directos de Ots por fecha de utilizacion")]
        public DataTable Listar_gasto_otsx(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_gasto_otsx(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "INFORMACION DE ACTIVIDADES DE LAS OT'S X Proyecto")]
        public string Listar_actividad_ot_proy(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Listar_actividad_ot_proy(N_CEO, V_CODDIV, V_CODPRY, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_ACTIVIDAD_OT_PROY";

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

        [WebMethod(Description = "Acta de Conformidad registradas en unisys con nro de acta en el campo cod_acta de la tabla gestion.CG_ACT_CONF")]
        public DataTable Listar_acta_conf_inf_gen(string V_CODUND, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_acta_conf_inf_gen(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = "Acta de Conformidad - Detalla las valorizaciones realizadas")]
        public DataTable Listar_acta_conf_solmn(string V_CODUND, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_acta_conf_solmn(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = " Acta de Conformidad registradas en unisys con nro de acta en el campo cod_acta de la tabla gestion")]
        public DataTable Listar_acta_conf(string V_CODUND, string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_acta_conf(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = " Actividades que incluyen Servicios en Ordenes de Trabajo ")]
        public DataTable Listar_detalle_ots_recursos(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return (new COt()).Listar_detalle_ots_recursos(N_CEO, V_CATVCRV, V_CODDIV, V_NROOTS, V_TIPRCS, UserName);
        }

        [WebMethod(Description = " Actividades que incluyen Servicios en Ordenes de Trabajo ")]
        public DataTable Listar_detalle_ots_recursos_pryc(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return (new COt()).Listar_detalle_ots_recursos_pryc(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, UserName);
        }

        [WebMethod(Description = " Actividades que incluyen Servicios en Ordenes de Trabajo  - string xml")]
        public string Listar_detalle_ots_recursos_pryc2(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Listar_detalle_ots_recursos_pryc(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, UserName);

                if (dt == null)
                {
                    dt = new DataTable("SP_Detalle_Ots_Recursos_Pryct");
                    dt.Columns.Add("Detalle  :", typeof(string));
                    dt.Rows.Add("El método Listar_detalle_ots_recursos_pryc devolvió null");
                }

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Detalle_Ots_Recursos_Pryct";

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
                DataTable dtError = new DataTable("SP_Detalle_Ots_Recursos_Pryct");
                dtError.Columns.Add("Detalle  :", typeof(string));
                dtError.Rows.Add(ex.Message);

                DataSet dset = new DataSet();
                dset.Tables.Add(dtError);

                using (StringWriter sw = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    dset.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                    return sw.ToString();
                }
            }
        }

        [WebMethod(Description = "Lista Actividades que incluyen Servicios en Ordenes de Trabajo  - string xml")]
        public string Listar_Detalle_Ot_Recursos_Pry_fec(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string D_FECHAINI_EMI, string D_FECHAFIN_EMI, string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Listar_Detalle_Ot_Recursos_Pry_fec(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, D_FECHAINI_EMI, D_FECHAFIN_EMI, UserName);

                if (dt == null)
                {
                    dt = new DataTable("Listar_Detalle_Ot_Recursos_Pry_fec");
                    dt.Columns.Add("Detalle  :", typeof(string));
                    dt.Rows.Add("El método Listar_detalle_ots_recursos_pryc devolvió null");
                }

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "Listar_Detalle_Ot_Recursos_Pry_fec";

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
                DataTable dtError = new DataTable("Listar_Detalle_Ot_Recursos_Pry_fec");
                dtError.Columns.Add("Detalle  :", typeof(string));
                dtError.Rows.Add(ex.Message);

                DataSet dset = new DataSet();
                dset.Tables.Add(dtError);

                using (StringWriter sw = new StringWriter())
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    dset.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                    return sw.ToString();
                }
            }
        }


        [WebMethod(Description = "Informacion de actividades por Ordenes de Trabajo")]
        public DataTable Listar_indicadores(string V_CO, string V_DIVISION, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new COt()).Listar_actividades_jg_man(V_CO, V_DIVISION, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "1. Costo OT")]
        public string Listar_Lista_costo_ot(string V_CEO, string V_DIV, string V_PERIODO, string V_GD, string V_OT_TER,
          string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Listar_Lista_costo_ot(V_CEO, V_DIV, V_PERIODO, V_GD, V_OT_TER, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Lista_costo_ot";

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

        [WebMethod(Description = "1. Costo OT en funcion del usuario ingresado")]
        public string Lista_costo_ot_user(string V_CEO, string V_DIV, string V_PERIODO, string V_GD, string V_OT_TER,
          string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Lista_costo_ot_user(V_CEO, V_DIV, V_PERIODO, V_GD, V_OT_TER, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Lista_costo_ot_user";

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

        [WebMethod(Description = "4.- Proyecto Utilización MAT-SER (submarinos)")]
        public DataTable Listar_DETALLE_GASTO_PRY_OT_UTISU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string V_NROOTS, string UserName)
        {
            return (new COt()).Listar_DETALLE_GASTO_PRY_OT_UTISU(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "8.-Proyecto Programa de Adquisiciones (submarinos)")]
        public DataTable Listar_DET_GASTO_PRY_OT_PGMSU(string V_Centro_Operativo, string V_División, string V_Proyecto,
            string UserName)
        {
            return (new COt()).Listar_DET_GASTO_PRY_OT_PGMSU(V_Centro_Operativo, V_División, V_Proyecto, UserName);
        }

        [WebMethod(Description = "9.-Proyecto Vales Salida de Materiales (submarinos)")]
        public DataTable Listar_DET_GASTO_PRY_OT_VSMSU(string V_Centro_Operativo, string V_División, string V_Proyecto,
            string UserName)
        {
            return (new COt()).Listar_DET_GASTO_PRY_OT_VSMSU(V_Centro_Operativo, V_División, V_Proyecto, UserName);
        }

        [WebMethod(Description = "1.-lista_ot_fac")]
        public string Listar_OT_Fac(string N_CEO, string V_CODDIV, string V_ESTADO, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Listar_OT_Fac(N_CEO, V_CODDIV, V_ESTADO, D_FECHAINI, D_FECHAFIN, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Lista_OT_Fac";

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

        [WebMethod(Description = "Lista Valorizacion de MGP con OT por año")]
        public DataTable Lista_Valorizacion_OT_Callao(string sCentro, string sCodigoDivision, string sFechaIni, string sFechaFin, string UserName)
        {
            return (new COtsValorizacion()).Lista_Valorizacion_OT_Callao(sCentro, sCodigoDivision, sFechaIni, sFechaFin, UserName);
        }

        [WebMethod(Description = "Lista Valorizacion de MGP con OT por año (String-xml)")]
        public string Lista_Valorizacion_OT_Callao2(string sCentro, string sCodigoDivision, string sFechaIni, string sFechaFin, string UserName)
        {
            try
            {
                DataTable dt = (new COtsValorizacion()).Lista_Valorizacion_OT_Callao(sCentro, sCodigoDivision, sFechaIni, sFechaFin, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_lista_100_2575";

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
                sMensaje = ex.Message.ToString();
                throw new HttpException(500, "Error interno del servidor " + sMensaje, ex);
            }
        }

        [WebMethod(Description = "Impresion de Ots")]
        public string Impresion_OTs(string V_OT, string V_COD_DIV, string UserName)
        {
            try
            {
                DataTable dt = (new COt()).Impresion_OTs(V_OT, V_COD_DIV, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Impresion_OT";

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

        #region Procedimientos almacenados de clasificacion: Valorizacion

        [WebMethod(Description = "Listado de actividades de Valorizacion")]
        public DataTable Listar_est_actividad(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new CValorizacion()).Listar_est_actividad(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Listado de actividades de Valorizacion 2")]
        public DataTable Listar_est_actividad_01(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new CValorizacion()).Listar_est_actividad_01(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Valorizaciones de Mtto.")]
        public DataTable Listar_lista_ots_se_01(string V_ANIO, string V_OPCION, string UserName)
        {
            return (new CValorizacion()).Listar_lista_ots_se_01(V_ANIO, V_OPCION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionr(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionr(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionr_(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionr_(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionrproy(string V_CO, string V_DIVISION, string V_OT, string V_PROYECTO, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionrproy(V_CO, V_DIVISION, V_OT, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion por fecha _ Recursos")]
        public DataTable Listar_valorizacionrproy_02(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionrproy_02(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionrunidad(string N_CEO, string V_CODCLI, string V_CODDIV, string V_CODUND, string V_PERIODO, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionrunidad(N_CEO, V_CODCLI, V_CODDIV, V_CODUND, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Listado Recursos de  las Valorizaciones x periodo")]
        public DataTable Listar_valorizacionrxan(string N_CEO, string V_CODDIV, string V_PAAMM, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionrxan(N_CEO, V_CODDIV, V_PAAMM, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos 01")]
        public DataTable Listar_valorizacionr01(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionr01(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion por fecha _ Recursos")]
        public DataTable Listar_valorizacionrproy01(string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CValorizacion()).Listar_valorizacionrproy01(V_CO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Submarinos

        [WebMethod(Description = "12. Registro de Ventas Serie 021. Registro de Ventas Serie 021")]
        public DataTable Listar_Registro_Ventas_Serie_021(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Tipo_Documento, string V_Origen, string V_Serie, string V_Concepto, string UserName)
        {
            return (new CSubmarinos()).Listar_Registro_Ventas_Serie_021(V_Centro_Operativo, D_Año, D_Mes,
                V_Tipo_Documento, V_Origen, V_Serie, V_Concepto, UserName);
        }

        [WebMethod(Description = "13. Parte de Cobranzas Serie 021. Parte de Cobranzas Serie 021")]
        public DataTable Listar_Parte_Cobranzas_Serie_021(string V_Centro_Operativo, string D_Año_de_Proceso,
            string D_Mes, string UserName)
        {
            return (new CSubmarinos()).Listar_Parte_Cobranzas_Serie_021(V_Centro_Operativo, D_Año_de_Proceso, D_Mes,
                UserName);
        }

        [WebMethod(Description = "3.-Proyecto Ordenes de Servicios Avance. AVANCE POR ORDENES DE SERVICIO DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_DET_GASTO_PRY_OT_OSE_AVASU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string V_NROOTS, string UserName)
        {
            return (new CSubmarinos()).Listar_DET_GASTO_PRY_OT_OSE_AVASU(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS,
                UserName);
        }

        [WebMethod(Description = "5.-Proyecto Utilización MOB Ruc. UTILIZACION DE MOB DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_DET_GASTO_PRY_OT_MOB_RUCSU(string N_CEO, string V_CODDIV, string V_CODPRY,
            string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return (new CSubmarinos()).Listar_DET_GASTO_PRY_OT_MOB_RUCSU(N_CEO, V_CODDIV, V_CODPRY, D_FECHAINI,
                D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "11. Egresos Directos PRCS. Egresos Directos - PROY.RECUPERACION CAPACIDAD SUBMARINA")]
        public DataTable Listar_Egresos_Directos_PRCS(string V_Centro_Operativo, string D_Año, string D_Mes_Desde,
            string D_Mes_Hasta, string UserName)
        {
            return (new CSubmarinos()).Listar_Egresos_Directos_PRCS(V_Centro_Operativo, D_Año, D_Mes_Desde,
                D_Mes_Hasta, UserName);
        }

        [WebMethod(Description = "15. Mayor Auxliar de Canceladas FxP. Mayor Auxliar de Canceladas FxP")]
        public DataTable Listar_Mayor_Auxiliar_Cancelada(string v_anio, string v_mes, string v_cta, string v_ruc1,
            string v_ruc2, string v_docu, string UserName)
        {
            return (new CSubmarinos()).Listar_Mayor_Auxiliar_Cancelada(v_anio, v_mes, v_cta, v_ruc1, v_ruc2, v_docu,
                UserName);
        }

        #endregion
    }
}
