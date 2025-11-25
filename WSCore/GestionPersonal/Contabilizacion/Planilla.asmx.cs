using EntidadNegocio.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionPersonal.Contabilizacion;

namespace WSCore.GestionPersonal.Contabilizacion
{
    /// <summary>
    /// Descripción breve de Planilla
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Planilla : System.Web.Services.WebService
    {
        [WebMethod]
        public void InsertaEncabSubDiario(string CODEMP, string CODSUC, string NUMASTO, int DIAASTO, int MESASTO, int ANOASTO, string TIPMON, string CBCPTO, string PGLOSA, double VALASTO, int NUMITEM_ASTO, string TIPASTO, string INDCM, string INDIPR, string INDPRS, string INDCRM, string USUARIOING, string USUARIOAUT, double VALASTO_ME, int DIACMB, int MESCMB, int ANOCMB, string TIPCMB)
        {
            try
            {
                EncabADBE oEncabAD = new EncabADBE();
                oEncabAD.Codemp = CODEMP;
                oEncabAD.Codsuc = CODSUC;
                oEncabAD.Numasto = NUMASTO;
                oEncabAD.Diaasto = DIAASTO;
                oEncabAD.Mesasto = MESASTO;
                oEncabAD.Anoasto = ANOASTO;
                oEncabAD.Tipmon = TIPMON;
                oEncabAD.Cbcpto = CBCPTO;
                oEncabAD.Pglosa = PGLOSA;
                oEncabAD.Valasto = VALASTO;
                oEncabAD.Numitem_asto = NUMITEM_ASTO;
                oEncabAD.Tipasto = TIPASTO;
                oEncabAD.Indcm = INDCM;
                oEncabAD.Indipr = INDIPR;
                oEncabAD.Indprs = INDPRS;
                oEncabAD.Indcrm = INDCRM;
                oEncabAD.Usuarioing = USUARIOING;
                oEncabAD.Usuarioaut = USUARIOAUT;
                oEncabAD.Valasto_me = VALASTO_ME;
                oEncabAD.Diacmb = DIACMB;
                oEncabAD.Mescmb = MESCMB;
                oEncabAD.Anocmb = ANOCMB;
                oEncabAD.Tipcmb = TIPCMB;

                int idResult = (new CEncabAD()).Eliminar(oEncabAD.Codemp, oEncabAD.Codsuc, oEncabAD.Anoasto.ToString(), oEncabAD.Mesasto.ToString(), oEncabAD.Cbcpto);
                string Result = "";
                if (idResult == 1)
                {
                    Result = (new CEncabAD()).Insertar(oEncabAD).ToString();
                    Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(Result);
                }
                else
                {
                    Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(idResult.ToString());
                }
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("0");
            }
        }

        [WebMethod]
        public void InsertaDetalleSubDiario(string CODEMP, string CODSUC, int NUMASTO, int NUMITEM_MOV, int DIAASTO, int MESASTO, int ANOASTO, string CBCPTO, string SUCMOV, string TIPCTA, string CODGRUP, string CODCTA, string CODSUB_CTA, string DIGV, string NUMDOC_ANA, string PDIST, string DIGV_D, string PDES, string INDD_H, double VALMOV, string PCC, double VALMEX)
        {
            try
            {
                DetalleADBE oDetalleADBE = new DetalleADBE();
                oDetalleADBE.Codemp = CODEMP;
                oDetalleADBE.Codsuc = CODSUC;
                oDetalleADBE.Numasto = NUMASTO;
                oDetalleADBE.Numitem_mov = NUMITEM_MOV;
                oDetalleADBE.Diaasto = DIAASTO;
                oDetalleADBE.Mesasto = MESASTO;
                oDetalleADBE.Anoasto = ANOASTO;
                oDetalleADBE.Cbcpto = CBCPTO;
                oDetalleADBE.Sucmov = SUCMOV;
                oDetalleADBE.Tipcta = TIPCTA;
                oDetalleADBE.Codgrup = CODGRUP;
                oDetalleADBE.Codcta = CODCTA;
                oDetalleADBE.Codsub_cta = CODSUB_CTA;
                oDetalleADBE.Digv = DIGV;
                oDetalleADBE.Numdoc_ana = NUMDOC_ANA;
                oDetalleADBE.Pdist = PDIST;
                oDetalleADBE.Digv_d = DIGV_D;
                oDetalleADBE.Pdes = PDES;
                oDetalleADBE.Indd_h = INDD_H;
                oDetalleADBE.Valmov = VALMOV;
                oDetalleADBE.Pcc = PCC;
                oDetalleADBE.Valmex = VALMEX;
                // oDetalleADBE.Valajt_cm = VALAJT_CM;
                // oDetalleADBE.Valorfinan = VALORFINAN;

                string Result = (new CDetalleAD()).Insertar(oDetalleADBE).ToString();
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(Result);
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("0");
            }
        }

        [WebMethod]
        public void TransferenciaFinal(string CODEMP, int ANOASTO, int MESASTO, string CBCPTO)
        {
            try
            {
                EncabADBE oEncabAD = new EncabADBE();
                oEncabAD.Codemp = CODEMP;
                oEncabAD.Anoasto = ANOASTO;
                oEncabAD.Mesasto = MESASTO;
                oEncabAD.Cbcpto = CBCPTO;
                int idResult = (new CCBDetalleAD()).TanferenciaFinal(oEncabAD);
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(idResult.ToString());
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("0");
            }
        }

        [WebMethod]
        public void CostodePersonalToUNISYS(int CODEMP, int ANOPRC, int MESPRC, string CODDIV, int CODOTS, double CNTNOR, double MNTNOR, double CNTSBT, double MNTSBT, double CNTINC, double MNTINC, string CODCC)
        {
            try
            {
                CostoPlanillaBE oCostoPlanillaBE = new CostoPlanillaBE();

                oCostoPlanillaBE.CodEmp = CODEMP;
                oCostoPlanillaBE.AnoPrc = ANOPRC;
                oCostoPlanillaBE.MesPrc = MESPRC;
                oCostoPlanillaBE.CodDiv = CODDIV;
                oCostoPlanillaBE.CodOts = CODOTS;
                oCostoPlanillaBE.CntNor = CNTNOR;
                oCostoPlanillaBE.MntNor = MNTNOR;
                oCostoPlanillaBE.CntSbt = CNTSBT;
                oCostoPlanillaBE.MntSbt = MNTSBT;
                oCostoPlanillaBE.CntInc = CNTINC;
                oCostoPlanillaBE.MntInc = MNTINC;
                oCostoPlanillaBE.CodCC = CODCC;

                int idResult = (new CCostoPlanilla()).Insertar(oCostoPlanillaBE);
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(idResult.ToString());
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("0");
            }
        }

        [WebMethod]
        public void EliminarCostodePersonalToUNISYS(int CODEMP, int ANOPRC, int MESPRC)
        {
            try
            {
                int idResult = (new CCostoPlanilla()).Eliminar(CODEMP, ANOPRC, MESPRC);
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(idResult.ToString());
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("0");
            }
        }
    }
}
