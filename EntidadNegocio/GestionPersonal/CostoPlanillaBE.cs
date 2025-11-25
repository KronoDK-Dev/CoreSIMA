using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class CostoPlanillaBE : BaseBE
    {
        private int codEmp;
        private int anoPrc;
        private int mesPrc;
        private string codDiv;
        private int codOts;
        private double cntNor;
        private double mntNor;
        private double cntSbt;
        private double mntSbt;
        private double cntInc;
        private double mntInc;
        private string codCC;

        public int CodEmp
        {
            get { return codEmp; }
            set { this.codEmp = value; }
        }
        public int AnoPrc
        {
            get { return anoPrc; }
            set { this.anoPrc = value; }
        }

        public int MesPrc
        {
            get { return mesPrc; }
            set { this.mesPrc = value; }
        }

        public string CodDiv
        {
            get { return codDiv; }
            set { this.codDiv = value; }
        }

        public int CodOts
        {
            get { return codOts; }
            set { this.codOts = value; }
        }

        public double CntNor
        {
            get { return cntNor; }
            set { this.cntNor = value; }
        }

        public double MntNor
        {
            get { return mntNor; }
            set { this.mntNor = value; }
        }

        public double CntSbt
        {
            get { return cntSbt; }
            set { this.cntSbt = value; }
        }

        public double MntSbt
        {
            get { return mntSbt; }
            set { this.mntSbt = value; }
        }

        public double CntInc
        {
            get { return cntInc; }
            set { this.cntInc = value; }
        }

        public double MntInc
        {
            get { return mntInc; }
            set { this.mntInc = value; }
        }

        public string CodCC
        {
            get { return codCC; }
            set { this.codCC = value; }
        }
    }
}
