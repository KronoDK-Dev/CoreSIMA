using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Controladora.GestionCostos;

namespace WSCore.GestionCostos
{
    /// <summary>
    /// Descripción breve de Costos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Costos : System.Web.Services.WebService
    {
        #region Procedimientos almacenados de clasificacion: Costos

        [WebMethod(Description = "Resumen - Costos de Producción (Por Línea de Negocio)")]
        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return (new CCostos()).Listar_costo_prod_linea_neg_resu(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }

        [WebMethod(Description = "Detalle - Costos de Producción(Por Línea de Negocio)")]
        public DataTable Listar_costo_prod_linea_neg_det(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return (new CCostos()).Listar_costo_prod_linea_neg_det(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }

        [WebMethod(Description = "Detalle - Mano de Obra Improductiva por Naturaleza de Gasto")]
        public DataTable Listar_ManoObra_ImprodNatuG_Det(string V_Centro_Operativo, string D_Año_de_Proceso,
            string D_Mes, string UserName)
        {
            return (new CCostos()).Listar_ManoObra_ImprodNatuG_Det(V_Centro_Operativo, D_Año_de_Proceso,
            D_Mes, UserName);
        }

        [WebMethod(Description = "Detalle - Costo de Venta por Linea de Negocio")]
        public DataTable Listar_Costo_Prod_Linea_Neg_Det(string D_Año, string D_Mes, string V_Centro_Operativo,
            string V_Linea_Negocio, string UserName)
        {
            return (new CCostos()).Listar_Costo_Prod_Linea_Neg_Det(D_Año, D_Mes, V_Centro_Operativo,
             V_Linea_Negocio, UserName);
        }

        [WebMethod(Description = "Resumen - Costo de Venta por Linea de Negocio")]
        public DataTable Listar_Costo_VentasLineaNegocioRes(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Linea_Negocio, string UserName)
        {
            return (new CCostos()).Listar_Costo_VentasLineaNegocioRes(V_Centro_Operativo, D_Año, D_Mes,
            V_Linea_Negocio, UserName);
        }

        [WebMethod(Description = "Resumen - Costo de Productos en Proceso por Linea de Negocio")]
        public DataTable Listar_CostPro_por_Linea_Neg_R(string Centro_Operativo, string Periodo, string Linea_Negocio,
            string UserName)
        {
            return (new CCostos()).Listar_CostPro_por_Linea_Neg_R(Centro_Operativo, Periodo, Linea_Negocio, UserName);
        }

        [WebMethod(Description = "Detalle  - Costo de Productos en Proceso por Linea de Negocio")]
        public DataTable Listar_CostPro_por_Linea_Neg_D(string Centro_Operativo, string Periodo, string Linea_Negocio,
            string UserName)
        {
            return (new CCostos()).Listar_CostPro_por_Linea_Neg_D(Centro_Operativo, Periodo, Linea_Negocio,
            UserName);
        }

        [WebMethod(Description = "1. Resumen - Horas Hombre Normal Utilizadas por Division")]
        public DataTable Listar_Hors_HombreNormalUtili_Divi(string V_Centro_Operativo, string D_Año, string D_Mes,
            string UserName)
        {
            return (new CCostos()).Listar_Hors_HombreNormalUtili_Divi(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        [WebMethod(Description = "1.1. Resumen - Distribucion de Costos Indirectos por Division")]
        public DataTable Listar_Distri_Costo_Grup_Resu(string V_Centro_Operativo, string D_Año, string D_Mes,
           string UserName)
        {
            return (new CCostos()).Listar_Distri_Costo_Grup_Resu(V_Centro_Operativo, D_Año, D_Mes, UserName);
        }

        [WebMethod(Description = "1.2. Detalle     - Distribucion de Costos Indirectos por Division")]
        public DataTable Listar_Distri_Costo_Grup_CC_Det(string V_Centro_Operativo, string D_Año, string D_Mes, string V_Grupo_CC_Desde, string V_Grupo_CC_Hasta,
          string UserName)
        {
            return (new CCostos()).Listar_Distri_Costo_Grup_CC_Det(V_Centro_Operativo, D_Año, D_Mes, V_Grupo_CC_Desde, V_Grupo_CC_Hasta,
           UserName);
        }

        [WebMethod(Description = "1.2. Detalle     - Distribucion de Costos Indirectos por Division")]
        public DataTable Listar_Mano_Obra_Directa_Div_Det(string V_Centro_Operativo, string D_Año, string D_Mes, string V_Division_Inicial, string V_Division_Final,
        string UserName)
        {
            return (new CCostos()).Listar_Mano_Obra_Directa_Div_Det(V_Centro_Operativo, D_Año, D_Mes, V_Division_Inicial, V_Division_Final,
         UserName);
        }

        [WebMethod(Description = "13. Costos directo de ot por centro de costo")]
        public string Listar_CostosDirectos_OT_CC(string V_Centro_Operativo, string v_Anio, string v_Mes, string V_Linea_Neg, string UserName)
        {
            try
            {
                DataTable dt = (new CCostos()).Listar_CostosDirectos_OT_CC(V_Centro_Operativo, v_Anio, v_Mes, V_Linea_Neg, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_CostosDirectos_OT_CC";

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

        [WebMethod(Description = "5. Materiales en Proyectos por centro operativo")]
        public string Listar_Materiales_en_Proyectos(string V_Centro_Operativo, string v_materiales, string UserName)
        {
            try
            {
                DataTable dt = (new CCostos()).Listar_Materiales_en_Proyectos(V_Centro_Operativo, v_materiales, UserName);

                if (dt != null)
                {
                    DataTable dtCopy = dt.Copy();
                    dtCopy.TableName = "SP_MATERIAL_EN_PROYECTO";

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
                    return "NULL";
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(500, "Error interno del servidor", ex);
            }
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Pagos

        [WebMethod(Description = "Detalle - Analisis de Gastos (Por C.Costo y Naturaleza)")]
        public DataTable Listar_analisis_gastos_ccnatudet(string D_AÑO_DE_PROCESO, string D_MES_DE_PROCESO, string V_CENTRO_OPERATIVO, string V_CUENTA_MAYOR, string UserName)
        {
            return (new CPagos()).Listar_analisis_gastos_ccnatudet(D_AÑO_DE_PROCESO, D_MES_DE_PROCESO, V_CENTRO_OPERATIVO, V_CUENTA_MAYOR, UserName);
        }

        [WebMethod(Description = "Detalle - Analisis de Gastos Directos de OT por Items de Asiento")]
        public DataTable Listar_analisis_gast_itemsasient(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            return (new CPagos()).Listar_analisis_gast_itemsasient(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Ventas

        [WebMethod(Description = "2. Ventas diferidas x OT (detalle)")]
        public DataTable Listar_Ventas_diferidas_x_OT_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO, string V_DIVISION, string UserName)
        {
            return (new CVentas()).Listar_Ventas_diferidas_x_OT_detalle(V_PERIODO, V_CENTRO_OPERATIVO, V_DIVISION, UserName);
        }

        [WebMethod(Description = "3. Ventas diferidas  x documento (detalle)")]
        public DataTable Listar_Ventas_diferidas_x_Doc_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO, string V_DIVISION, string UserName)
        {
            return (new CVentas()).Listar_Ventas_diferidas_x_OT_detalle(V_PERIODO, V_CENTRO_OPERATIVO, V_DIVISION, UserName);
        }

        #endregion
    }
}
