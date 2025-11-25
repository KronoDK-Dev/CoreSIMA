using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class EncabADBE : BaseBE
    {
        private string codemp;
        private string codsuc;
        private string numasto;
        private int diaasto;
        private int mesasto;
        private int anoasto;
        private string tipmon;
        private string cbcpto;
        private string pglosa;
        private double valasto;
        private int numitem_asto;
        private string tipasto;
        private string indcm;
        private string indipr;
        private string indprs;
        private string indcrm;
        private string usuarioing;
        private string usuarioaut;
        private double valasto_me;
        private int diacmb;
        private int mescmb;
        private int anocmb;
        private string tipcmb;

        public string Codemp { get { return codemp; } set { codemp = value; } }
        public string Codsuc { get { return codsuc; } set { codsuc = value; } }
        public string Numasto { get { return numasto; } set { numasto = value; } }
        public int Diaasto { get { return diaasto; } set { diaasto = value; } }
        public int Mesasto { get { return mesasto; } set { mesasto = value; } }
        public int Anoasto { get { return anoasto; } set { anoasto = value; } }
        public string Tipmon { get { return tipmon; } set { tipmon = value; } }
        public string Cbcpto { get { return cbcpto; } set { cbcpto = value; } }
        public string Pglosa { get { return pglosa; } set { pglosa = value; } }
        public double Valasto { get { return valasto; } set { valasto = value; } }
        public int Numitem_asto { get { return numitem_asto; } set { numitem_asto = value; } }
        public string Tipasto { get { return tipasto; } set { tipasto = value; } }
        public string Indcm { get { return indcm; } set { indcm = value; } }
        public string Indipr { get { return indipr; } set { indipr = value; } }
        public string Indprs { get { return indprs; } set { indprs = value; } }
        public string Indcrm { get { return indcrm; } set { indcrm = value; } }
        public string Usuarioing { get { return usuarioing; } set { usuarioing = value; } }
        public string Usuarioaut { get { return usuarioaut; } set { usuarioaut = value; } }
        public double Valasto_me { get { return valasto_me; } set { valasto_me = value; } }
        public int Diacmb { get { return diacmb; } set { diacmb = value; } }
        public int Mescmb { get { return mescmb; } set { mescmb = value; } }
        public int Anocmb { get { return anocmb; } set { anocmb = value; } }
        public string Tipcmb { get { return tipcmb; } set { tipcmb = value; } }
    }
}
