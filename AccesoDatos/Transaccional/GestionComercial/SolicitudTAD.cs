using EntidadNegocio;
using Log;
using Newtonsoft.Json.Linq;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadNegocio.GestionComercial;
using Utilitario;
using static AccesoDatos.BaseAD;

namespace AccesoDatos.Transaccional.GestionComercial
{
    public class SolicitudTAD : BaseAD, IMantenimientoTAD
    {
        readonly string sComercial = ConfigurationManager.AppSettings["E_COMERCIAL"];

        public int Eliminar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            throw new NotImplementedException();
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Inserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string InsertarSolicitud(BaseBE oBaseBE, string sAmbiente = "T")
        {
            SolicitudBE oSolicitudBE = (SolicitudBE)oBaseBE;

            if (string.IsNullOrEmpty(oSolicitudBE.V_AMBIENTE) == false) // capturamos ambiente
            { sAmbiente = oSolicitudBE.V_AMBIENTE; }
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oSolicitudBE.ToString(true));
                string PackageName = sComercial + ".pkg_comercial.PR_INS_UPD_SOLICITUD";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oSolicitudBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , oInfoMetodoBE.VoidParams
                    , ""
                    , Helper.MensajesIngresarMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I))
                );

                OracleParameter[] Params = new OracleParameter[62];
                Params[0] = new OracleParameter("V_AMBIENTE", OracleDbType.Varchar2);
                Params[0].Direction = ParameterDirection.Input;
                Params[0].Value = sAmbiente;

                Params[1] = new OracleParameter("X_COD_CEO", OracleDbType.Varchar2);
                Params[1].Direction = ParameterDirection.Input;
                Params[1].Value = (object)oSolicitudBE.X_COD_CEO;

                Params[2] = new OracleParameter("X_COD_DIV", OracleDbType.Varchar2);
                Params[2].Direction = ParameterDirection.Input;
                Params[2].Value = (object)oSolicitudBE.X_COD_DIV;

                Params[3] = new OracleParameter("X_NRO_STR", OracleDbType.Int32);
                Params[3].Direction = ParameterDirection.Input;
                Params[3].Value = (object)oSolicitudBE.X_NRO_STR;

                Params[4] = new OracleParameter("X_COD_AUS", OracleDbType.Varchar2);
                Params[4].Direction = ParameterDirection.Input;
                Params[4].Value = (object)oSolicitudBE.X_COD_AUS;

                Params[5] = new OracleParameter("X_TIP_STR", OracleDbType.Varchar2);
                Params[5].Direction = ParameterDirection.Input;
                Params[5].Value = (object)oSolicitudBE.X_TIP_STR;

                Params[6] = new OracleParameter("X_COD_CLI", OracleDbType.Int32);
                Params[6].Direction = ParameterDirection.Input;
                Params[6].Value = (object)oSolicitudBE.X_COD_CLI;

                Params[7] = new OracleParameter("X_COD_UND", OracleDbType.Int32);
                Params[7].Direction = ParameterDirection.Input;
                Params[7].Value = (object)oSolicitudBE.X_COD_UND;

                Params[8] = new OracleParameter("X_COD_SIS", OracleDbType.Int32);
                Params[8].Direction = ParameterDirection.Input;
                Params[8].Value = (object)oSolicitudBE.X_COD_SIS;

                Params[9] = new OracleParameter("X_COD_SUB", OracleDbType.Int32);
                Params[9].Direction = ParameterDirection.Input;
                Params[9].Value = (object)oSolicitudBE.X_COD_SUB;

                Params[10] = new OracleParameter("X_COD_EQP", OracleDbType.Int32);
                Params[10].Direction = ParameterDirection.Input;
                Params[10].Value = (object)oSolicitudBE.X_COD_EQP;

                Params[11] = new OracleParameter("X_FEC_STR", OracleDbType.Varchar2);
                Params[11].Direction = ParameterDirection.Input;
                Params[11].Value = (object)oSolicitudBE.X_FEC_STR;

                Params[12] = new OracleParameter("X_NRO_VAL", OracleDbType.Int32);
                Params[12].Direction = ParameterDirection.Input;
                Params[12].Value = (object)oSolicitudBE.X_NRO_VAL;

                Params[13] = new OracleParameter("X_TIP_TBJ", OracleDbType.Varchar2);
                Params[13].Direction = ParameterDirection.Input;
                Params[13].Value = (object)oSolicitudBE.X_TIP_TBJ;

                Params[14] = new OracleParameter("X_COD_PRO", OracleDbType.Int32);
                Params[14].Direction = ParameterDirection.Input;
                Params[14].Value = (object)oSolicitudBE.X_COD_PRO;

                Params[15] = new OracleParameter("X_EST_ATL", OracleDbType.Varchar2);
                Params[15].Direction = ParameterDirection.Input;
                Params[15].Value = (object)oSolicitudBE.X_EST_ATL;

                Params[16] = new OracleParameter("X_DES_ABR", OracleDbType.Varchar2);
                Params[16].Direction = ParameterDirection.Input;
                Params[16].Value = (object)oSolicitudBE.X_DES_ABR;

                Params[17] = new OracleParameter("X_DES_DET", OracleDbType.Varchar2);
                Params[17].Direction = ParameterDirection.Input;
                Params[17].Value = (object)oSolicitudBE.X_DES_DET;

                Params[18] = new OracleParameter("X_NRO_PRO", OracleDbType.Int32);
                Params[18].Direction = ParameterDirection.Input;
                Params[18].Value = (object)oSolicitudBE.X_NRO_PRO;

                Params[19] = new OracleParameter("X_REF_STR", OracleDbType.Varchar2);
                Params[19].Direction = ParameterDirection.Input;
                Params[19].Value = (object)oSolicitudBE.X_REF_STR;

                Params[20] = new OracleParameter("X_UBC_EQP", OracleDbType.Varchar2);
                Params[20].Direction = ParameterDirection.Input;
                Params[20].Value = (object)oSolicitudBE.X_UBC_EQP;

                Params[21] = new OracleParameter("X_TIP_TAR", OracleDbType.Varchar2);
                Params[21].Direction = ParameterDirection.Input;
                Params[21].Value = (object)oSolicitudBE.X_TIP_TAR;

                Params[22] = new OracleParameter("X_CLS_TBJ", OracleDbType.Varchar2);
                Params[22].Direction = ParameterDirection.Input;
                Params[22].Value = (object)oSolicitudBE.X_CLS_TBJ;

                Params[23] = new OracleParameter("X_COD_NAV", OracleDbType.Int32);
                Params[23].Direction = ParameterDirection.Input;
                Params[23].Value = (object)oSolicitudBE.X_COD_NAV;

                Params[24] = new OracleParameter("X_FEC_REF", OracleDbType.Varchar2);
                Params[24].Direction = ParameterDirection.Input;
                Params[24].Value = (object)oSolicitudBE.X_FEC_REF;

                Params[25] = new OracleParameter("X_FEC_ACC", OracleDbType.Varchar2);
                Params[25].Direction = ParameterDirection.Input;
                Params[25].Value = (object)oSolicitudBE.X_FEC_ACC;

                Params[26] = new OracleParameter("X_ALIAS_STR", OracleDbType.Varchar2);
                Params[26].Direction = ParameterDirection.Input;
                Params[26].Value = (object)oSolicitudBE.X_ALIAS_STR;

                Params[27] = new OracleParameter("X_IND_CNV", OracleDbType.Varchar2);
                Params[27].Direction = ParameterDirection.Input;
                Params[27].Value = (object)oSolicitudBE.X_IND_CNV;

                Params[28] = new OracleParameter("X_FEC_CNV", OracleDbType.Varchar2);
                Params[28].Direction = ParameterDirection.Input;
                Params[28].Value = (object)oSolicitudBE.X_FEC_CNV;

                Params[29] = new OracleParameter("X_IBP", OracleDbType.Varchar2);
                Params[29].Direction = ParameterDirection.Input;
                Params[29].Value = (object)oSolicitudBE.X_IBP;

                Params[30] = new OracleParameter("X_TIP_OTS", OracleDbType.Varchar2);
                Params[30].Direction = ParameterDirection.Input;
                Params[30].Value = (object)oSolicitudBE.X_TIP_OTS;

                Params[31] = new OracleParameter("X_USR_REG", OracleDbType.Varchar2);
                Params[31].Direction = ParameterDirection.Input;
                Params[31].Value = (object)oSolicitudBE.X_USR_REG;

                Params[32] = new OracleParameter("X_FEC_REG", OracleDbType.Varchar2);
                Params[32].Direction = ParameterDirection.Input;
                Params[32].Value = (object)oSolicitudBE.X_FEC_REG;

                Params[33] = new OracleParameter("X_OTS_TAR", OracleDbType.Varchar2);
                Params[33].Direction = ParameterDirection.Input;
                Params[33].Value = (object)oSolicitudBE.X_OTS_TAR;

                Params[34] = new OracleParameter("X_FEC_RCP_STR", OracleDbType.Varchar2);
                Params[34].Direction = ParameterDirection.Input;
                Params[34].Value = (object)oSolicitudBE.X_FEC_RCP_STR;

                Params[35] = new OracleParameter("X_HRA_RCP_STR", OracleDbType.Varchar2);
                Params[35].Direction = ParameterDirection.Input;
                Params[35].Value = (object)oSolicitudBE.X_HRA_RCP_STR;

                Params[36] = new OracleParameter("X_FEC_ENT_VAL", OracleDbType.Varchar2);
                Params[36].Direction = ParameterDirection.Input;
                Params[36].Value = (object)oSolicitudBE.X_FEC_ENT_VAL;

                Params[37] = new OracleParameter("X_HRA_ENT_VAL", OracleDbType.Varchar2);
                Params[37].Direction = ParameterDirection.Input;
                Params[37].Value = (object)oSolicitudBE.X_HRA_ENT_VAL;

                Params[38] = new OracleParameter("X_DIQUE", OracleDbType.Varchar2);
                Params[38].Direction = ParameterDirection.Input;
                Params[38].Value = (object)oSolicitudBE.X_DIQUE;

                Params[39] = new OracleParameter("X_COD_SEC", OracleDbType.Varchar2);
                Params[39].Direction = ParameterDirection.Input;
                Params[39].Value = (object)oSolicitudBE.X_COD_SEC;

                Params[40] = new OracleParameter("X_TIPO_VAL", OracleDbType.Varchar2);
                Params[40].Direction = ParameterDirection.Input;
                Params[40].Value = (object)oSolicitudBE.X_TIPO_VAL;

                Params[41] = new OracleParameter("X_NRO_CTTO", OracleDbType.Varchar2);
                Params[41].Direction = ParameterDirection.Input;
                Params[41].Value = (object)oSolicitudBE.X_NRO_CTTO;

                Params[42] = new OracleParameter("X_NRO_SOL_JDE", OracleDbType.Int32);
                Params[42].Direction = ParameterDirection.Input;
                Params[42].Value = (object)oSolicitudBE.X_NRO_SOL_JDE;

                Params[43] = new OracleParameter("X_EST_PRC", OracleDbType.Int32);
                Params[43].Direction = ParameterDirection.Input;
                Params[43].Value = (object)oSolicitudBE.X_EST_PRC;

                Params[44] = new OracleParameter("X_REF_STR_MGP", OracleDbType.Varchar2);
                Params[44].Direction = ParameterDirection.Input;
                Params[44].Value = (object)oSolicitudBE.X_REF_STR_MGP;

                Params[45] = new OracleParameter("X_FEC_REF_MGP", OracleDbType.Varchar2);
                Params[45].Direction = ParameterDirection.Input;
                Params[45].Value = (object)oSolicitudBE.X_FEC_REF_MGP;

                Params[46] = new OracleParameter("X_COD_CLIENTE", OracleDbType.Varchar2);
                Params[46].Direction = ParameterDirection.Input;
                Params[46].Value = (object)oSolicitudBE.X_COD_CLIENTE;

                Params[47] = new OracleParameter("X_PROYECTO", OracleDbType.Varchar2);
                Params[47].Direction = ParameterDirection.Input;
                Params[47].Value = (object)oSolicitudBE.X_PROYECTO;

                Params[48] = new OracleParameter("X_SUBLINEA", OracleDbType.Varchar2);
                Params[48].Direction = ParameterDirection.Input;
                Params[48].Value = (object)oSolicitudBE.X_SUBLINEA;

                Params[49] = new OracleParameter("X_OTGENERICA", OracleDbType.Varchar2);
                Params[49].Direction = ParameterDirection.Input;
                Params[49].Value = (object)oSolicitudBE.X_OTGENERICA;

                Params[50] = new OracleParameter("X_NUMACTI", OracleDbType.Varchar2);
                Params[50].Direction = ParameterDirection.Input;
                Params[50].Value = (object)oSolicitudBE.X_NUMACTI;

                Params[51] = new OracleParameter("X_ACTIVIDAD", OracleDbType.Varchar2);
                Params[51].Direction = ParameterDirection.Input;
                Params[51].Value = (object)oSolicitudBE.X_ACTIVIDAD;

                Params[52] = new OracleParameter("X_ESTRUCTURA", OracleDbType.Varchar2);
                Params[52].Direction = ParameterDirection.Input;
                Params[52].Value = (object)oSolicitudBE.X_ESTRUCTURA;

                Params[53] = new OracleParameter("X_ESTACIONREGISTRO", OracleDbType.Varchar2);
                Params[53].Direction = ParameterDirection.Input;
                Params[53].Value = (object)oSolicitudBE.X_ESTACIONREGISTRO;

                Params[54] = new OracleParameter("X_V_SOLICITUD_ID", OracleDbType.Varchar2);
                Params[54].Direction = ParameterDirection.Input;
                Params[54].Value = (object)oSolicitudBE.X_V_SOLICITUD_ID;

                Params[55] = new OracleParameter("X_V_EMBARCACION_ID", OracleDbType.Varchar2);
                Params[55].Direction = ParameterDirection.Input;
                Params[55].Value = (object)oSolicitudBE.X_V_EMBARCACION_ID;

                Params[56] = new OracleParameter("X_V_CLIENTE_ID", OracleDbType.Varchar2);
                Params[56].Direction = ParameterDirection.Input;
                Params[56].Value = (object)oSolicitudBE.X_V_CLIENTE_ID;

                Params[57] = new OracleParameter("X_UND_OPE", OracleDbType.Varchar2);
                Params[57].Direction = ParameterDirection.Input;
                Params[57].Value = (object)oSolicitudBE.X_UND_OPE;

                Params[58] = new OracleParameter("X_NRO_REVISION", OracleDbType.Varchar2);
                Params[58].Direction = ParameterDirection.Input;
                Params[58].Value = (object)oSolicitudBE.X_NRO_REVISION;

                Params[59] = new OracleParameter("X_COD_PRESUPUESTO", OracleDbType.Varchar2);
                Params[59].Direction = ParameterDirection.Input;
                Params[59].Value = (object)oSolicitudBE.X_COD_PRESUPUESTO;

                Params[60] = new OracleParameter("X_REMITIDO", OracleDbType.Varchar2);
                Params[60].Direction = ParameterDirection.Input;
                Params[60].Value = (object)oSolicitudBE.X_REMITIDO;

                Params[61] = new OracleParameter("w_error", OracleDbType.Varchar2);
                Params[61].Direction = ParameterDirection.Output;
                Params[61].Size = 20;

                string IDe;

                string ID = (string)Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackageName, Params);

                if (string.IsNullOrWhiteSpace(ID))
                {
                    IDe = "0";
                }
                else
                {
                    JObject json = JObject.Parse(ID);
                    IDe = (string)json["w_error"];
                }

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oSolicitudBE.UserName
                    , oInfoMetodoBE.FullName
                    , NombreMetodo
                    , PackageName
                    , ""
                    , "Return ID:" + IDe
                    , Helper.MensajesSalirMetodo()
                    , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                return IDe;
            }
            catch (Exception ex)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oSolicitudBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), ex.Message);
                return "FALLO EN PROCESAMIENTO";
            }
        }
    }
}
