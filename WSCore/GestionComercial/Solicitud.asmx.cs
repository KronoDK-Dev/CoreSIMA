using Controladora.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Controladora.GestionComercial;
using EntidadNegocio.GestionComercial;

namespace WSCore.GestionComercial
{
    /// <summary>
    /// Descripción breve de Solicitud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Solicitud : System.Web.Services.WebService
    {
        readonly string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];

        [WebMethod(Description = "Detalle de la Solicitud")]
        public DataTable DetalleSolicitud(string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new cSolicitud()).DetalleSolicitud(sAmbiente, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        [WebMethod(Description = "Detalle de la Solicitud 2")]
        public DataTable DetalleSolicitud2(string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new cSolicitud()).DetalleSolicitud2(sAmbiente, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        [WebMethod(Description = "Lista de Solicitudes de Trabajo por CEO")]
        public DataTable ListarSolicitudTrabajo(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI,
            string V_FEC_STR_FIN, string UserName)
        {
            return (new cSolicitud()).ListarSolicitudTrabajo(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
        }

        [WebMethod(Description = "Lista de Solicitudes de Trabajo , por Metodo xml string")]
        public string ListarSolicitudTrabajo2(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI,
            string V_FEC_STR_FIN, string UserName)
        {
            try
            {
                DataTable dt = (new cSolicitud()).ListarSolicitudTrabajo(sAmbiente, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);

                DataTable dtCopy = dt.Copy();
                dtCopy.TableName = "PR_GET_SOLICITUD";

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

        [WebMethod(Description = "Inserción de Solicitudes de Trabajo")]
        public string InsertarSolicitud(
            string v_ambiente, string v_cod_ceo, string v_cod_div, string v_nro_str, string v_cod_aus, string v_tip_str,
            string v_cod_cli, string v_cod_und, string v_cod_sis, string v_cod_sub, string v_cod_eqp, string v_fec_str,
            string v_nro_val, string v_tip_tbj, string v_cod_pro, string v_est_atl, string v_des_abr, string v_des_det,
            string v_nro_pro, string v_ref_str, string v_ubc_eqp, string v_tip_tar, string v_cls_tbj, string v_cod_nav,
            string v_fec_ref, string v_fec_acc, string v_alias_str, string v_ind_cnv, string v_fec_cnv, string v_ibp,
            string v_tip_ots, string v_usr_reg, string v_fec_reg, string v_ots_tar, string v_fec_rcp_str, string v_hra_rcp_str,
            string v_fec_ent_val, string v_hra_ent_val, string v_dique, string v_cod_sec, string v_tipo_val, string v_nro_ctto,
            string v_nro_sol_jde, string v_est_prc, string v_ref_str_mgp, string v_fec_ref_mgp, string v_cod_cliente, string v_proyecto,
            string v_sublinea, string v_otgenerica, string v_numacti, string v_actividad, string v_estructura, string v_estacionregistro,
            string v_v_solicitud_id, string v_v_embarcacion_id, string v_v_cliente_id, string v_und_ope, string v_nro_revision,
            string v_cod_presupuesto, string v_remitido)
        {
            SolicitudBE solicitud = new SolicitudBE
            {
                X_COD_CEO = v_cod_ceo,
                X_COD_DIV = v_cod_div,
                X_NRO_STR = string.IsNullOrEmpty(v_nro_str) ? 0 : Convert.ToInt32(v_nro_str),
                X_COD_AUS = v_cod_aus,
                X_TIP_STR = v_tip_str,
                X_COD_CLI = string.IsNullOrEmpty(v_cod_cli) ? 0 : Convert.ToInt32(v_cod_cli),
                X_COD_UND = string.IsNullOrEmpty(v_cod_und) ? 0 : Convert.ToInt32(v_cod_und),
                X_COD_SIS = string.IsNullOrEmpty(v_cod_sis) ? 0 : Convert.ToInt32(v_cod_sis),
                X_COD_SUB = string.IsNullOrEmpty(v_cod_sub) ? 0 : Convert.ToInt32(v_cod_sub),
                X_COD_EQP = string.IsNullOrEmpty(v_cod_eqp) ? 0 : Convert.ToInt32(v_cod_eqp),
                X_FEC_STR = v_fec_str,
                X_NRO_VAL = string.IsNullOrEmpty(v_nro_val) ? 0 : Convert.ToInt32(v_nro_val),
                X_TIP_TBJ = v_tip_tbj,
                X_COD_PRO = string.IsNullOrEmpty(v_cod_pro) ? 0 : Convert.ToInt32(v_cod_pro),
                X_EST_ATL = v_est_atl,
                X_DES_ABR = v_des_abr,
                X_DES_DET = v_des_det,
                X_NRO_PRO = string.IsNullOrEmpty(v_nro_pro) ? 0 : Convert.ToInt32(v_nro_pro),
                X_REF_STR = v_ref_str,
                X_UBC_EQP = v_ubc_eqp,
                X_TIP_TAR = v_tip_tar,
                X_CLS_TBJ = v_cls_tbj,
                X_COD_NAV = string.IsNullOrEmpty(v_cod_nav) ? 0 : Convert.ToInt32(v_cod_nav),
                X_FEC_REF = v_fec_ref,
                X_FEC_ACC = v_fec_acc,
                X_ALIAS_STR = v_alias_str,
                X_IND_CNV = v_ind_cnv,
                X_FEC_CNV = v_fec_cnv,
                X_IBP = v_ibp,
                X_TIP_OTS = v_tip_ots,
                X_USR_REG = v_usr_reg,
                X_FEC_REG = v_fec_reg,
                X_OTS_TAR = v_ots_tar,
                X_FEC_RCP_STR = v_fec_rcp_str,
                X_HRA_RCP_STR = v_hra_rcp_str,
                X_FEC_ENT_VAL = v_fec_ent_val,
                X_HRA_ENT_VAL = v_hra_ent_val,
                X_DIQUE = v_dique,
                X_COD_SEC = v_cod_sec,
                X_TIPO_VAL = v_tipo_val,
                X_NRO_CTTO = v_nro_ctto,
                X_NRO_SOL_JDE = string.IsNullOrEmpty(v_nro_sol_jde) ? 0 : Convert.ToInt32(v_nro_sol_jde),
                X_EST_PRC = string.IsNullOrEmpty(v_est_prc) ? 0 : Convert.ToInt32(v_est_prc),
                X_REF_STR_MGP = v_ref_str_mgp,
                X_FEC_REF_MGP = v_fec_ref_mgp,
                X_COD_CLIENTE = v_cod_cliente,
                X_PROYECTO = v_proyecto,
                X_SUBLINEA = v_sublinea,
                X_OTGENERICA = v_otgenerica,
                X_NUMACTI = v_numacti,
                X_ACTIVIDAD = v_actividad,
                X_ESTRUCTURA = v_estructura,
                X_ESTACIONREGISTRO = v_estacionregistro,
                X_V_SOLICITUD_ID = v_v_solicitud_id,
                X_V_EMBARCACION_ID = v_v_embarcacion_id,
                X_V_CLIENTE_ID = v_v_cliente_id,
                X_UND_OPE = v_und_ope,
                X_NRO_REVISION = v_nro_revision,
                X_COD_PRESUPUESTO = v_cod_presupuesto,
                X_REMITIDO = v_remitido
            };

            try
            {
                string result = (new cSolicitud()).InsertarSolicitud(solicitud, sAmbiente);

                if (result.Contains('-') && result.Length > 4)
                    result = (new cGeneral()).LISTA_DESCRIP_ERRORES(result, v_usr_reg);

                result = result.Replace("S0", "\n S0");

                return result;
            }
            catch (Exception ex)
            {
                return "InsertarSolicitud | FALLO EN PROCESAMIENTO...\r\n" + ex.Message;
            }
        }

        [WebMethod(Description = "Inserción de Solicitudes de Trabajo")]
        public string InsertarSolicitud2(SolicitudBE oSolicitudBE, string UserName)
        {
            try
            {
                string result = (new cSolicitud()).InsertarSolicitud(oSolicitudBE);

                if (result.Contains('-') && result.Length > 4)
                    result = (new cGeneral()).LISTA_DESCRIP_ERRORES(result, UserName);
                result = result.Replace("S0", "\n S0");

                return result;
            }
            catch (Exception ex)
            {
                return "InsertarSolicitud | FALLO EN PROCESAMIENTO...\r\n" + ex.Message;
            }
        }

        [WebMethod(Description = "Lista Lineas de Negocio de Usuarios")]
        public DataTable Lista_lineas_Usuario(string sUsuario, string UserName)
        {
            return (new cSolicitud()).Lista_Lineas_Usuario(sUsuario, UserName);
        }
    }
}
