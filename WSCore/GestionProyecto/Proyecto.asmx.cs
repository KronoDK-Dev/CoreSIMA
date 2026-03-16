using AccesoDatos.NoTransaccional.GestionProyecto;
using AccesoDatos.Transaccional.GestionProyecto;
using Controladora.GestionPersonal;
using Controladora.GestionProyecto;
using EntidadNegocio.GestionComercial;
using EntidadNegocio.GestionProyecto;
using Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WSCore.GestionProyecto
{
    /// <summary>
    /// Descripción breve de Proyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Proyecto : System.Web.Services.WebService
    {
        readonly string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];
        string result;
        string s_pto;

        #region Procedimientos almacenados de clasificacion: Adquisiciones

        [WebMethod(Description = "PROGRAMA DE ADQUISICIONES DE REQUERIMIENTOS DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_pgmsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CAdquisiciones()).Listar_det_gasto_pry_ot_pgmsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Balance

        [WebMethod(Description = "Resumen x OT - Comparativo de Venta vs. Costo x Proyecto")]
        public DataTable Listar_comparventvscostoproyecot(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PERIODO, string V_PROYECTO, string UserName)
        {
            return (new CBalance()).Listar_comparventvscostoproyecotR(V_CENTRO_OPERATIVO, V_DIVISION, V_PERIODO, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Resumen x OT - Comparativo de Venta vs. Costo x Proyecto")]
        public DataTable Listar_comparventvscostoproyec_ot(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PERIODO, string V_PROYECTO, string UserName)
        {
            return (new CBalance()).Listar_comparventvscostoproyec_ot(V_CENTRO_OPERATIVO, V_DIVISION, V_PERIODO, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Facturacion

        [WebMethod(Description = "FACTURACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new CFacturacion()).Listar_detalle_gasto_pry_ot_fac(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Materiales

        [WebMethod(Description = "UTILIZACION DE MATERIALES Y SERVICIOS DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_uti(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CMateriales()).Listar_det_gasto_pry_ot_uti(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = " VALES DE SALIDA DE MATERIALES DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_vsm(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CMateriales()).Listar_det_gasto_pry_ot_vsm(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Mob

        [WebMethod(Description = "UTILIZACION DE MOB DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_mob(string D_FECHA_DE_TRABAJO_DESDE, string D_FECHA_DE_TRABAJO_HASTA, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new CMob()).Listar_det_gasto_pry_ot_mob(D_FECHA_DE_TRABAJO_DESDE, D_FECHA_DE_TRABAJO_HASTA, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "UTILIZACION DE MOB DE OT'S POR PROYECTOS V.2")]
        public string Listar_det_gasto_pry_ot_mob2(string D_FECHA_DE_TRABAJO_DESDE, string D_FECHA_DE_TRABAJO_HASTA, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            try
            {
                DataTable dt = (new CMob()).Listar_det_gasto_pry_ot_mob(D_FECHA_DE_TRABAJO_DESDE, D_FECHA_DE_TRABAJO_HASTA, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_DET_GASTO_PRY_OT_MOB";

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

        #region Procedimientos almacenados de clasificacion: Ordenes

        [WebMethod(Description = "AVANCE POR ORDENES DE SERVICIO DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_ose_ava(string N_CEO, string V_CODDIV, string V_CODPRY, string V_ORDSRV, string UserName)
        {
            return (new COrdenes()).Listar_det_gasto_pry_ot_ose_ava(N_CEO, V_CODDIV, V_CODPRY, V_ORDSRV, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_ose(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new COrdenes()).Listar_detalle_gasto_pry_ot_ose(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_oco(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new COrdenes()).Listar_det_gasto_pry_ot_oco(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTO (RESUMEN)")]
        public DataTable Listar_resumen_ose(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new COrdenes()).Listar_resumen_ose(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR FECHA DE EMISION")]
        public DataTable Listar_detalle_ose_femision(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return (new COrdenes()).Listar_detalle_ose_femision(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }

        [WebMethod(Description = "Listar Ordenes  de Compra y Servicio del Coproductor en JSON Streaming")]
        public void Listar_Ordenes_CS_Coproductor(string N_CEO, string UserName)
        {
            HttpContext context = HttpContext.Current;

            context.Response.BufferOutput = false;
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";

            context.Server.ScriptTimeout = 1800;

            IDataReader reader = null;

            try
            {
                reader = (new COrdenes()).Listar_Ordenes_CS_Coproductor(N_CEO, UserName);

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

        [WebMethod(Description = "Listar Ordenes CS (retorna DataTable)")]
        public DataTable Listar_Ordenes_CS_Coproductor_DT(string N_CEO, string UserName)
        {
            IDataReader reader = null;
            var dt = new DataTable("SP_Ordenes_CS");
            try
            {
                reader = (new COrdenes()).Listar_Ordenes_CS_Coproductor(N_CEO, UserName); // tu capa de datos
                if (reader == null) return dt;
                dt.Load(reader, LoadOption.Upsert);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close(); // IMPORTANTÍSIMO: libera la conexión
            }
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Ot

        [WebMethod(Description = "RELACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string AÑO, string UserName)
        {
            return (new COt()).Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, AÑO, UserName);
        }

        [WebMethod(Description = "RELACION DE OT'S POR PROYECTOS - TEST")]
        public DataTable Listar_detg_pry_ot_sinfact_test(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string AÑO, string UserName)
        {
            return (new COt()).Listar_detg_pry_ot_sinfact_test(CENTRO_OPERATIVO, DIVISION, PROYECTO, AÑO, UserName);
        }

        [WebMethod(Description = "02. OTS por Proyecto")]
        public DataTable Listar_ots_por_proyecto(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new COt()).Listar_ots_por_proyecto(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Pagos

        [WebMethod(Description = "GASTOS DIRECTOS DE OT'S  (SERVICIOS) POR PROYECTOS")]
        public DataTable Listar_resumen_ose_partida(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new CPagos()).Listar_resumen_ose_partida(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = " GASTOS DIRECTOS DE OT'S  (MATERIALES) POR PROYECTOS")]
        public DataTable Listar_det_gto_mat_pry_ot_partid(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return (new CPagos()).Listar_det_gto_mat_pry_ot_partid(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = " ORDENES DE COMPRA DE OT'S POR PROYECTOS con tipo cambio")]
        public DataTable Listar_det_gast_pry_ot_oco_ate_acu(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            try
            {
                return (new CPagos()).Listar_det_gast_pry_ot_oco_ate_acu(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "GASTOS DE PROYECTOS AGRUPADOR POR OT'S ")]
        public DataTable Listar_gastos_proyectos_ot_v3(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return (new CPagos()).Listar_gastos_proyectos_ot_v3(N_CEO, V_CODDIV, V_CODPRY, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Proyecto

        [WebMethod(Description = "Lista de proyectos")]
        public string ListarProyectos(string V_CEO, string V_UND_OPER, string V_LINEA, string V_FILTRO, string V_FECHAINI, string V_FECHAFIN)
        {
            try
            {
                DataTable dt = (new CProyecto()).ListarProyectos(V_CEO, V_UND_OPER, V_LINEA, V_FILTRO, V_FECHAINI, V_FECHAFIN, sAmbiente);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "PR_GET_PROYECTOS";

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

        [WebMethod(Description = "LISTAR OTS ASOCIADAS A PROYECTO")]
        public DataTable ListarOtSPorProyecto(string V_COD_PRY)
        {
            return (new CProyecto()).ListarOtSPorProyecto(V_COD_PRY, sAmbiente);
        }

        [WebMethod(Description = "LISTAR ADENDAS ASOCIADAS A PROYECTO")]
        public DataTable ListarAdendasPorProyecto(string V_COD_PRY)
        {
            return (new CProyecto()).ListarAdendasPorProyecto(V_COD_PRY, sAmbiente);
        }

        [WebMethod(Description = "Busca un registro de la tabla pd_pry_dat_gen por ID")]
        public ProyectoBE ListarProyectoPorId(string V_PRY_ID, string UserName)
        {
            return (ProyectoBE)(new CProyecto()).ListarProyectoPorId(V_PRY_ID, UserName, sAmbiente);
        }

        [WebMethod(Description = "Lista Cartas fianza")]
        public DataTable Listar_CartaFianzas(string v_ANIOCARTA, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_CartaFianzas(v_ANIOCARTA, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista viaticos proyectos")]
        public DataTable Listar_ViaticosProyectos(string v_ANIOCARTA, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_ViaticosProyectos(v_ANIOCARTA, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Rendicion Recibo_Caja_xProyecto")]
        public DataTable Listar_Rendicion_Recibo_Caja_xProyecto(string v_CEO, string v_ANIO, string V_CODPROYECTO, string v_TIPO, string UserName)
        {
            return (new CProyecto()).Listar_Rendicion_Recibo_Caja_xProyecto(v_CEO, v_ANIO, V_CODPROYECTO, v_TIPO, UserName);
        }

        [WebMethod(Description = "Lista Rendicion Recibo_Caja_xProyecto vers. 2")]
        public string Listar_Rendicion_Recibo_Caja_xProyecto2(string v_CEO, string v_ANIO, string V_CODPROYECTO, string v_TIPO, string UserName)
        {
            try
            {
                DataTable dt = (new CProyecto()).Listar_Rendicion_Recibo_Caja_xProyecto(v_CEO, v_ANIO, V_CODPROYECTO, v_TIPO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_RENDICION_RECIBO_CAJA_xPRY";

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Lista Costos estimados de OT de un Proyecto")]
        public DataTable Listar_OT_Costos_estimados_xProyecto(string v_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_OT_Costos_estimados_xProyecto(v_CEO, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Costos estimados de OT de un Proyecto vers. 2")]
        public string Listar_OT_Costos_estimados_xProyecto2(string v_CEO, string V_CODPROYECTO, string UserName)
        {
            try
            {
                DataTable dt = (new CProyecto()).Listar_OT_Costos_estimados_xProyecto(v_CEO, V_CODPROYECTO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_COSTOS_OT_ESTIMADOS";

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
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        [WebMethod(Description = "Lista viaticos Rendidos proyectos")]
        public DataTable Listar_Viaticos_Rendidos(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_Viaticos_Rendidos(V_CEO, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Cartas Fianzas proyectos")]
        public DataTable Listar_Cartas_Fianzas(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_Cartas_Fianzas(V_CEO, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Aportes Sencico por proyecto")]
        public DataTable Listar_Aportes_Sencico(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_Aportes_Sencico(V_CEO, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Ingresos/pagos por proyecto")]
        public DataTable Listar_Ingresos_Proyecto(string V_CEO, string V_CODPROYECTO, string UserName)
        {
            return (new CProyecto()).Listar_Ingresos_Proyecto(V_CEO, V_CODPROYECTO, UserName);
        }

        [WebMethod(Description = "Lista Planilla de un proyecto")]
        public DataTable Listar_Planilla_Proyecto(string V_CEO, string V_CODPROYECTO, string V_PERIODO, string UserName)
        {
            return (new CProyecto()).Listar_Planilla_Proyecto(V_CEO, V_CODPROYECTO, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Buscar Personal por codigo de pr u O7")]
        public DataTable Buscar_Colaborador_xCod(string V_CEO, string V_CODIGO)
        {
            return (new CPersonal()).Buscar_Colaborador_xCod(V_CEO, V_CODIGO);
        }


        [WebMethod(Description = "Obtiene Presupuesto de Proyecto por PK (CodProyecto + Sucursal).")]
        public DataTable Get_ProyectoPresupuesto(string V_FTPresupuesto_CodProyecto, string V_FTPresupuesto_Sucursal, string UserName)
        {
            try
            {
                // 1) Validaciones de entrada
                if (string.IsNullOrWhiteSpace(V_FTPresupuesto_CodProyecto))
                    throw new ArgumentNullException(nameof(V_FTPresupuesto_CodProyecto), "Código de proyecto es requerido.");

                if (string.IsNullOrWhiteSpace(V_FTPresupuesto_Sucursal))
                    throw new ArgumentNullException(nameof(V_FTPresupuesto_Sucursal), "Sucursal es requerida.");

                // 2) Log de entrada mínimo (evita null)
                var usuario = string.IsNullOrWhiteSpace(UserName) ? "(anon)" : UserName;
                // LogTransaccional.GrabarLogTransaccionalArchivo(... "IN Get_ProyectoPresupuesto cod=" + V_FTPresupuesto_CodProyecto + ", suc=" + V_FTPresupuesto_Sucursal + ", usr=" + usuario);

                // 3) Llamada a controladora
                var dt = (new CProyecto()).Get_ProyectoPresupuesto(V_FTPresupuesto_CodProyecto, V_FTPresupuesto_Sucursal, usuario);

                // 4) Defensive: evita NRE hacia el cliente

                // Si viene null, devuelve DT vacío con nombre
                if (dt == null)
                    return new DataTable("ProyectoPresupuesto");

                // Si viene sin nombre, ponle uno (ASMX lo requiere)
                if (string.IsNullOrWhiteSpace(dt.TableName))
                    dt.TableName = "ProyectoPresupuesto";


                // LogTransaccional.GrabarLogTransaccionalArchivo(... "OUT rows=" + dt.Rows.Count);
                return dt;
            }
            catch (Exception ex)
            {
                // Log detallado
                // LogTransaccional.GrabarLogTransaccionalArchivo(... "ERROR Get_ProyectoPresupuesto: " + ex.ToString());

                // No retornes null si tu cliente no lo espera; envía tabla vacía o deja que burbujee si quieres SOAP Fault
                throw;
            }
        }

        #endregion

        #region Procedimientos almacenados TRANSACCIONALES: Proyecto

        [WebMethod(Description = "GENERA PROYECTO ID")]
        public string GEN_PROYECTO_ID(string p_ceo, string p_unidOpe, string P_linea, string p_sublinea, string P_V_CLIENTE_ID)
        {
            return (new CProyecto()).GEN_PROYECTO_ID(p_ceo, p_unidOpe, P_linea, p_sublinea, P_V_CLIENTE_ID, sAmbiente);
        }

        [WebMethod(Description = "Inserta o actualiza un Proyecto")]
        public string InsertarProyecto(
          string X_COD_CEO, string X_COD_PRY, string X_COD_PROY_CH, string X_COD_DIV,
          string X_DES_PRY, string X_COD_ALM, string X_EST_ATL, string X_NRO_VAL_PRY,
          string X_USR_REG, string X_PRY_JDE, string X_EST_PRY,
          string X_TIPO_PRY, string X_FECINI_PRY, string X_FECFIN_PRY,
          string X_V_PRY_UNDOPER, string X_V_PRY_SUBLINEA, string X_V_CLIENTE_ID,
          string X_V_PRY_COD_JEFEPROY, string X_N_PRY_MONTO_SINIMP, string X_V_PRY_CODMONEDA,
          string X_N_PRY_ESLORA, string X_N_PRY_MANGA, string X_N_PRY_PUNTAL,
          string X_N_PRY_BODEGA, string X_V_PRY_ESTACIONW, string X_V_PRY_AUDITORIA,
          string X_V_PRY_OBSERVACIONES, string X_V_CORREO, string X_V_NROCASCO,
          string X_V_PRY_Convenio, string ACCION)
        {
            ProyectoBE oProyectoBE = new ProyectoBE
            {
                COD_CEO = X_COD_CEO,
                COD_PRY = X_COD_PRY,
                COD_PROY_CH = X_COD_PROY_CH,
                COD_DIV = X_COD_DIV,
                DES_PRY = X_DES_PRY,
                COD_ALM = X_COD_ALM,
                EST_ATL = X_EST_ATL,
                NRO_VAL_PRY = X_NRO_VAL_PRY,
                USR_REG = X_USR_REG,
                PRY_JDE = X_PRY_JDE,
                EST_PRY = X_EST_PRY,
                TIPO_PRY = X_TIPO_PRY,
                FECINI_PRY = X_FECINI_PRY,
                FECFIN_PRY = X_FECFIN_PRY,
                V_PRY_UNDOPER = X_V_PRY_UNDOPER,
                V_PRY_SUBLINEA = X_V_PRY_SUBLINEA,
                V_CLIENTE_ID = X_V_CLIENTE_ID,
                V_PRY_COD_JEFEPROY = X_V_PRY_COD_JEFEPROY,
                N_PRY_MONTO_SINIMP = X_N_PRY_MONTO_SINIMP,
                V_PRY_CODMONEDA = X_V_PRY_CODMONEDA,
                N_PRY_ESLORA = X_N_PRY_ESLORA,
                N_PRY_MANGA = X_N_PRY_MANGA,
                N_PRY_PUNTAL = X_N_PRY_PUNTAL,
                N_PRY_BODEGA = X_N_PRY_BODEGA,
                V_PRY_ESTACIONW = X_V_PRY_ESTACIONW,
                V_PRY_AUDITORIA = X_V_PRY_AUDITORIA,
                V_PRY_OBSERVACIONES = X_V_PRY_OBSERVACIONES,
                NROCASCO = X_V_NROCASCO,
                CORREO = X_V_CORREO,
                V_PRY_Convenio = X_V_PRY_Convenio

            };

            // Llamar al método para insertar o actualizar según la acción
            string result = (new CProyecto()).InsertarProyecto(oProyectoBE, ACCION, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Inserta o actualiza un adenda de proyecto")]
        public string InsertarAdendaProyecto(
            string X_COD_PRY, string X_NROADENDA, string X_MONTO, string X_MONEDA,
            string X_FECHA, string ACCION)
        {
            AdendaProyectoBE oAdendaProyectoBE = new AdendaProyectoBE
            {
                V_PROYADE_CODPRY = X_COD_PRY,
                N_PROYADE_NROADENDA = X_NROADENDA,
                N_PROYADE_MONTO = X_MONTO,
                V_PROYADE_MONEDA = X_MONEDA,
                D_PROYADE_FECHA = X_FECHA
            };

            // Llamar al método para insertar o actualizar según la acción
            string result = (new CProyecto()).InsertarAdendaProyecto(oAdendaProyectoBE, ACCION, sAmbiente);

            return result;
        }

        [WebMethod(Description = "Elimina adenda de un proyecto")]
        public string DEL_ADENDAPROYECTO(string P_CODPRY, string P_NROADENDA, string UserName)
        {
            return (new CProyecto()).DEL_ADENDAPROYECTO(P_CODPRY, P_NROADENDA, UserName, sAmbiente);
        }

        [WebMethod(Description = "Inserción o actualización de colaborador de proyecto")]
        public string Ins_upd_ColaboradorProy(ColaboradorProyectoBE oColaboradorBE)
        {
            try
            {
                s_pto = "1";
                result = (new CProyecto()).Ins_upd_ColaboradorProy(oColaboradorBE);

                // Si hay códigos de error CODIFICADOS EN TABLA, los traducimos a descripciones
                if (result.Contains('-') && result.Length > 4)
                    s_pto = "2";
                result = (new Controladora.General.cGeneral()).LISTA_DESCRIP_ERRORES(result, oColaboradorBE.UserName);
                s_pto = "3";
                result = result.Replace("S0", "\n S0");

                return result;
            }
            catch (Exception ex)
            {
                return "Ins_upd_ColaboradorProy | FALLO EN PROCESAMIENTO...\r\n" + ex.Message + " | " + result + " | " + s_pto;
            }
        }

        [WebMethod(Description = "Elimina un colaborador del proyecto")] // este tipo de metodos no se pueden probar con Postman, porque no se puede enviar un objeto complejo como parámetro
        public string Del_ColaboradorProy(ColaboradorProyectoBE oColaboradorBE)
        {
            try
            {
                s_pto = "1";
                result = (new CProyecto()).Del_ColaboradorProy(oColaboradorBE);
                return result;
            }
            catch (Exception ex)
            {
                return "Del_ColaboradorProy | FALLO EN PROCESAMIENTO...\r\n" + ex.Message + " | " + result + " | " + s_pto;
            }

        }

        [WebMethod(Description = "Lista los colaboradores por proyecto")]
        public DataTable Listar_ColaboradoresProyecto(string V_SUCURSAL, string V_PROYECTO)
        {
            return (new CProyecto()).Listar_ColaboradoresProyecto(V_SUCURSAL, V_PROYECTO);
        }

        [WebMethod(Description = "Autoriza a un colaborador a que consulte un proyecto")]
        public string AutorizaUsuarioProyecto(string userId, string proyId, string UserName)
        {
            return (new CProyecto()).InsertarUsuarioProyecto(userId, proyId, UserName);
        }


        [WebMethod(Description = "Inserta, actualiza o elimina Presupuesto de Proyecto (N_ACCION = 1/2/3).")]
        public string InsUpdDel_ProyectoPresupuesto(
                  string X_N_ACCION,
                  string X_V_FTPresupuesto_CodProyecto,
                  string X_V_FTPresupuesto_Sucursal,
                  string X_N_FTPresupuesto_CostoMOB,
                  string X_N_FTPresupuesto_CostoMAT,
                  string X_N_FTPresupuesto_CostoSER,
                  string X_N_FTPresupuesto_CostoIND,
                  string X_V_FTPresupuesto_USUARIO_AUDI,
                  string X_V_FTPresupuesto_ESTACIONW,
                  string X_V_FTPresupuesto_AUDITORIA
              )
        {
            // Mapeo estilo patrón: construir el BE con los X_*
            var oBE = new ProyectoPresupuestoBE
            {
                // Acción (1=INS, 2=UPD, 3=DEL)
                N_ACCION = ToInt32Safe(X_N_ACCION),

                // PK
                V_FTPresupuesto_CodProyecto = X_V_FTPresupuesto_CodProyecto,
                V_FTPresupuesto_Sucursal = X_V_FTPresupuesto_Sucursal,

                // Costos (parse seguros a decimal?; null si viene vacío)
                N_FTPresupuesto_CostoMOB = ToDecimalNullable(X_N_FTPresupuesto_CostoMOB),
                N_FTPresupuesto_CostoMAT = ToDecimalNullable(X_N_FTPresupuesto_CostoMAT),
                N_FTPresupuesto_CostoSER = ToDecimalNullable(X_N_FTPresupuesto_CostoSER),
                N_FTPresupuesto_CostoIND = ToDecimalNullable(X_N_FTPresupuesto_CostoIND),

                // Auditoría
                V_FTPresupuesto_USUARIO_AUDI = X_V_FTPresupuesto_USUARIO_AUDI,
                V_FTPresupuesto_ESTACIONW = X_V_FTPresupuesto_ESTACIONW,
                V_FTPresupuesto_AUDITORIA = X_V_FTPresupuesto_AUDITORIA
            };

            // Delegar a la controladora según tu patrón
            return (new CProyecto()).InsUpdDel_ProyectoPresupuesto(oBE);
        }

        #endregion


        // ============================
        // Helpers de parseo seguros
        // ============================
        private static int ToInt32Safe(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            int n;
            return Int32.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out n) ? n : 0;
        }

        private static decimal? ToDecimalNullable(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;

            // Aceptar tanto coma como punto; normalizamos a punto para InvariantCulture
            var v = value.Replace(',', '.');
            decimal d;
            return Decimal.TryParse(v, NumberStyles.Number, CultureInfo.InvariantCulture, out d) ? d : (decimal?)null;
        }
    

       //------------------------------------------
    }
}
