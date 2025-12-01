using Controladora.GestionActivoFijo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WSCore.GestionActivoFijo
{
    /// <summary>
    /// Descripción breve de ActivoFijo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ActivoFijo : System.Web.Services.WebService
    {

        [WebMethod(Description = "")]
        public string Listar_actfijo_cons_inv(string UserName)
        {
            try
            {
                DataTable dt = (new cActivoFijo()).Listar_actfijo_cons_inv(UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_actfijo_Cons_Inv";

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

        [WebMethod(Description = "")]
        public DataTable Listar_formato_7_1(string COD_EMP, string N_ANIO, string UserName)
        {
            return (new cActivoFijo()).Listar_formato_7_1(COD_EMP, N_ANIO, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_invent_actxgrupoysubgrsmn(string COD_EMPE, string GRUPOBN, string SUBGRUPOBN,
            string TIPOACTV, string UserName)
        {
            return (new cActivoFijo()).Listar_invent_actxgrupoysubgrsmn(COD_EMPE, GRUPOBN, SUBGRUPOBN, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxcc(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL,
            string TIPOACTV, string UserName)
        {
            return (new cActivoFijo()).Listar_inventario_activosxcc(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxccrsm(string CCOSTO1, string CCOSTO2, string COD_EMPE,
            string TIPOACTV, string UserName)
        {
            return (new cActivoFijo()).Listar_inventario_activosxccrsm(CCOSTO1, CCOSTO2, COD_EMPE, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV,
            string UserName)
        {
            return (new cActivoFijo()).Listar_inventario_activosxcustod(COD_EMPE, COD_ROL, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_actsgrup_sub(string COD_EMP, string EST_BIEN, string GRUPO, string SUBGRUPO,
            string TIPO_BIEN, string UserName)
        {
            return (new cActivoFijo()).Listar_inventario_actsgrup_sub(COD_EMP, EST_BIEN, GRUPO, SUBGRUPO, TIPO_BIEN, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Lista_Bienes_toma_inventario(string CODEMP, string NRO_PR, string CCO_INI, string CCO_FIN,
            string UserName)
        {
            return (new cActivoFijo()).Lista_Bienes_toma_inventario(CODEMP, NRO_PR, CCO_INI, CCO_FIN, UserName);
        }

        [WebMethod(Description = "")]
        public string Lista_actfijo_Pen(string UserName)
        {
            try
            {
                DataTable dt = (new cActivoFijo()).Lista_actfijo_Pen(UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_actfijo_Pen";

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

        [WebMethod(Description = "")]
        public DataTable Lista_AltasMes_ActF(string Anio, string Mes, string UserName)
        {
            return (new cActivoFijo()).Lista_AltasMes_ActF(Anio, Mes, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Lista_AltasCuentOrd_M(string Anio, string Mes, string UserName)
        {
            return (new cActivoFijo()).Lista_AltasCuentOrd_M(Anio, Mes, UserName);
        }

        [WebMethod(Description = "Inventario de Bienes por Grupo y Subgrupo")]
        public string Lista_Inventario_ActsGrup_Sub(string COD_EMP, string EST_BIEN, string TIPO_BIEN,
            string sGRUPO, string sSUBGRUPO, string UserName)
        {
            try
            {
                DataTable dt = (new cActivoFijo()).Lista_Inventario_ActsGrup_Sub(COD_EMP, EST_BIEN, TIPO_BIEN,
                    sGRUPO, sSUBGRUPO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Inventario_ActsGrup_Sub";

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

        [WebMethod(Description = "Inventario de Bienes por Grupo y Subgrupo")]
        public string Lista_Inventario_ActsGrup_Sub2(string COD_EMP, string EST_BIEN, string TIPO_BIEN,
            string sGRUPO, string sSUBGRUPO, string UserName)
        {
            try
            {
                DataTable dt = (new cActivoFijo()).Lista_Inventario_ActsGrup_Sub2(COD_EMP, EST_BIEN, TIPO_BIEN,
                    sGRUPO, sSUBGRUPO, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "SP_Inventario_ActsGrup_Sub";

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

        [WebMethod(Description = "")]
        public DataTable Lista_Invent_ActxGrupoySubGRSMN(string COD_EMP, string TIPOACTV, string GRUPOBN, string SUBGRUPOBN, string UserName)
        {
            return (new cActivoFijo()).Lista_Invent_ActxGrupoySubGRSMN(COD_EMP, TIPOACTV, GRUPOBN, SUBGRUPOBN, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Lista_Inventario_ActivosxCC(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL, string TIPOACTV, string UserName)
        {
            return (new cActivoFijo()).Lista_Inventario_ActivosxCC(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }
    }
}
