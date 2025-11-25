using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class OrdendePagoCtactableBE : BaseBE
    {
        private string codemp;
        private string folchq;
        private string itmcnlchq;
        private string cuenta;
        private string nrodocana;
        private string dist;
        private string des;
        private string inddh;
        private double valmov;
        private string cc;
        private double valmex;
        private double tipcmb;
        private double valorg;

        public string Codemp
        {
            get { return codemp; }
            set { codemp = value; }
        }
        public string Folchq
        {
            get { return folchq; }
            set { folchq = value; }
        }

        public string Itmcnlchq
        {
            get { return itmcnlchq; }
            set { itmcnlchq = value; }
        }

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        public string Nrodocana
        {
            get { return nrodocana; }
            set { nrodocana = value; }
        }

        public string Dist
        {
            get { return dist; }
            set { dist = value; }
        }

        public string Des
        {
            get { return des; }
            set { des = value; }
        }

        public string Inddh
        {
            get { return inddh; }
            set { inddh = value; }
        }

        public double Valmov
        {
            get { return valmov; }
            set { valmov = value; }
        }

        public string Cc
        {
            get { return cc; }
            set { cc = value; }
        }

        public double Valmex
        {
            get { return valmex; }
            set { valmex = value; }
        }

        public double Tipcmb
        {
            get { return tipcmb; }
            set { tipcmb = value; }
        }

        public double Valorg
        {
            get { return valorg; }
            set { valorg = value; }
        }
    }
}
