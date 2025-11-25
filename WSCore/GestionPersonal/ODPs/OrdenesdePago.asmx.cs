using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.GestionPersonal.Pagos;
using EntidadNegocio.GestionPersonal;

namespace WSCore.GestionPersonal.ODPs
{
    /// <summary>
    /// Descripción breve de OrdenesdePago
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class OrdenesdePago : System.Web.Services.WebService
    {
        [WebMethod]
        public void Agregar(string COD_EMP, string FOL_RQR, string USR_SOL, string RUT_BNF, string BNF_RQR, double MNT_RQR, string COD_MON, int DIA_RQR, int MES_RQR, int ANO_RQR, double SLD_PDT, string OBS_1, double MNT_OFC_RQR, string BC_STM_DST, double TIP_CMB)
        {
            try
            {
                OrdendePagoBE oOrdendePagoBE = new OrdendePagoBE();
                oOrdendePagoBE.CodEmp = COD_EMP;
                oOrdendePagoBE.Folrqr = FOL_RQR;
                oOrdendePagoBE.UsrSol = USR_SOL;
                oOrdendePagoBE.Rutbnf = RUT_BNF;
                oOrdendePagoBE.Bnfrqr = BNF_RQR;
                oOrdendePagoBE.Mntrqr = MNT_RQR;
                oOrdendePagoBE.Codmon = COD_MON;
                oOrdendePagoBE.Diarqr = DIA_RQR;
                oOrdendePagoBE.Mesrqr = MES_RQR;
                oOrdendePagoBE.Anorqr = ANO_RQR;
                oOrdendePagoBE.Sdpdt = SLD_PDT;
                oOrdendePagoBE.Obs1 = OBS_1;
                oOrdendePagoBE.Mntofcrqr = MNT_OFC_RQR;
                oOrdendePagoBE.Bcstmdst = BC_STM_DST;
                oOrdendePagoBE.Tipcmb = TIP_CMB;

                string IdResult = (new COrdendePago()).Insertar(oOrdendePagoBE).ToString();

                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(IdResult);
            }
            catch (Exception ex)
            {

                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("-1");
            }
        }

        [WebMethod]
        public void AgregarCtaCtable(string COD_EMP, string FOL_CHQ, string ITM_CNL_CHQ, string CUENTA, string NRO_DOC_ANA, string DIST, string DES, string IND_D_H, double VAL_MOV, string CC, double VAL_MEX, double TIP_CMB, double VAL_ORG)
        {
            try
            {
                string IdResult = "0";
                OrdendePagoCtactableBE oOrdendePagoCtactableBE = new OrdendePagoCtactableBE();
                oOrdendePagoCtactableBE.Codemp = COD_EMP;
                oOrdendePagoCtactableBE.Folchq = FOL_CHQ;
                oOrdendePagoCtactableBE.Itmcnlchq = ITM_CNL_CHQ;
                oOrdendePagoCtactableBE.Cuenta = CUENTA;
                oOrdendePagoCtactableBE.Nrodocana = NRO_DOC_ANA;
                oOrdendePagoCtactableBE.Dist = DIST;
                oOrdendePagoCtactableBE.Des = DES;
                oOrdendePagoCtactableBE.Inddh = IND_D_H;
                oOrdendePagoCtactableBE.Valmov = VAL_MOV;
                oOrdendePagoCtactableBE.Cc = CC;
                oOrdendePagoCtactableBE.Valmex = VAL_MEX;
                oOrdendePagoCtactableBE.Tipcmb = TIP_CMB;
                oOrdendePagoCtactableBE.Valorg = VAL_ORG;

                IdResult = (new COrdendePagoCtaCtable()).Insertar(oOrdendePagoCtactableBE);

                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(IdResult);
            }
            catch (Exception ex)
            {
                Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos("-1");
            }
        }
    }
}
