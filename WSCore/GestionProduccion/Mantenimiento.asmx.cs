using Controladora.GestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WSCore.GestionProduccion
{
    /// <summary>
    /// Descripción breve de Mantenimiento
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Mantenimiento : System.Web.Services.WebService
    {

        [WebMethod(Description = "1. gasto_otx_fecha | Gastos Directos de Ots por fecha de utilizacion")]
        public DataTable Listar_gasto_otx_fecha(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string UserName)
        {
            return (new CMantenimiento()).Listar_gasto_otx_fecha(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, UserName);
        }

        [WebMethod(Description = "1. gasto_otx_fecha (STRING XML) | Gastos Directos de Ots por fecha de utilizacion")]
        public string Listar_gasto_otx_fecha2(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string UserName)
        {
            try
            {
                DataTable dt = (new CMantenimiento()).Listar_gasto_otx_fecha(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_gasto_otx_fecha";

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

        [WebMethod(Description = "4. lista_ots_se | Gastos por Ordenes de Trabajo")]
        public DataTable Listar_ots_se(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string V_BIEN, string UserName)
        {
            return (new CMantenimiento()).Listar_ots_se(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, V_BIEN, UserName);
        }

        [WebMethod(Description = "4. lista_ots_se (STRING XML) | Gastos por Ordenes de Trabajo")]
        public string Listar_ots_se2(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string V_BIEN, string UserName)
        {
            try
            {
                DataTable dt = (new CMantenimiento()).Listar_ots_se(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, V_BIEN, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Lista_OTS_SE";

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

        [WebMethod(Description = "4. lista_ots_se (STRING XML) | Gastos por Ordenes de Trabajo TEST")]
        public string Listar_ots_se_v2(string v_CO, string v_DIVISION, string N_OT, string D_Fecha_Inicio, string D_Fecha_Termino, string v_BIEN, string UserName)
        {
            try
            {
                DataTable dt = (new CMantenimiento()).Listar_ots_se_v2(v_CO, v_DIVISION, N_OT, D_Fecha_Inicio, D_Fecha_Termino, v_BIEN, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_lista_ots_se_v2";

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

        [WebMethod(Description = "5. consumo_mat_ots | Consumo de materiales de las OT´s")]
        public DataTable Listar_consumo_mat_ots(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string UserName)
        {
            return (new CMantenimiento()).Listar_consumo_mat_ots(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, UserName);
        }

        [WebMethod(Description = "5. consumo_mat_ots (STRING XML) | Consumo de materiales de las OT´s")]
        public string Listar_consumo_mat_ots2(string V_CEO, string V_CODDIV, string V_OT, string V_FINICIO, string V_FTERMINO, string UserName)
        {
            try
            {
                DataTable dt = (new CMantenimiento()).Listar_consumo_mat_ots(V_CEO, V_CODDIV, V_OT, V_FINICIO, V_FTERMINO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Consumo_Mat_Ots";

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

        [WebMethod(Description = "12. RecOtSE | Lista Recursos empleados en el año por Ot de SE")]
        public DataTable Listar_recursos_ots(string V_Anio, string UserName)
        {
            return (new CMantenimiento()).Listar_recursos_ots(V_Anio, UserName);
        }

        [WebMethod(Description = "12. RecOtSE  (STRING XML)| Lista Recursos empleados en el año por Ot de SE")]
        public string Listar_recursos_ots2(string V_Anio, string UserName)
        {
            try
            {
                DataTable dt = (new CMantenimiento()).Listar_recursos_ots(V_Anio, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_RecOtsSE";

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
    }
}
