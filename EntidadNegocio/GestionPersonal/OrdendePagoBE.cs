using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class OrdendePagoBE : BaseBE
    {
        private int nroFolio;
        private string codEmp;
        private string folrqr;
        private string usrSol;
        private string rutbnf;
        private string bnfrqr;
        private double mntrqr;
        private string codmon;
        private int diarqr;
        private int mesrqr;
        private int anorqr;
        private double sldpdt;
        private string obs1;
        private double mntofcrqr;
        private string bcstmdst;
        private double tipcmb;



        public int NroFolio
        {
            get { return nroFolio; }
            set { nroFolio = value; }
        }
        public string CodEmp
        {
            get { return codEmp; }
            set { codEmp = value; }
        }

        public string Folrqr
        {
            get { return folrqr; }
            set { folrqr = value; }
        }

        public string UsrSol
        {
            get { return usrSol; }
            set { usrSol = value; }
        }

        public string Rutbnf
        {
            get { return rutbnf; }
            set { rutbnf = value; }
        }

        public string Bnfrqr
        {
            get { return bnfrqr; }
            set { bnfrqr = value; }
        }

        public double Mntrqr
        {
            get { return mntrqr; }
            set { mntrqr = value; }
        }

        public string Codmon
        {
            get { return codmon; }
            set { codmon = value; }
        }

        public int Diarqr
        {
            get { return diarqr; }
            set { diarqr = value; }
        }

        public int Mesrqr
        {
            get { return mesrqr; }
            set { mesrqr = value; }
        }

        public int Anorqr
        {
            get { return anorqr; }
            set { anorqr = value; }
        }

        public double Sdpdt
        {
            get { return sldpdt; }
            set { sldpdt = value; }
        }

        public string Obs1
        {
            get { return obs1; }
            set { obs1 = value; }
        }

        public double Mntofcrqr
        {
            get { return mntofcrqr; }
            set { mntofcrqr = value; }
        }

        public string Bcstmdst
        {
            get { return bcstmdst; }
            set { bcstmdst = value; }
        }

        public double Tipcmb
        {
            get { return tipcmb; }
            set { tipcmb = value; }
        }
    }
}
