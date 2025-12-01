using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionProduccion
{
    public class ActividadBE : BaseBE
    {
        public string CodigoCEO { get; set; }
        public string CodigoActiv { get; set; }
        public int NroCrv { get; set; }
        public int NroVal { get; set; }
        public string CodigoTll { get; set; }
        public string CodigoDiv { get; set; }
        public int CodigoOT { get; set; }
        public string DescripcionD { get; set; }
        public string UserReg { get; set; }

        public ActividadBE()
        {

        }

        public ActividadBE(string _CodigoCEO, string _CodigoActiv, int _NroCrv, int _NroVal, string _CodigoTll, string _CodigoDiv, int _CodigoOT, string _DescripcionD, string _UserReg)
        {
            this.CodigoCEO = _CodigoCEO;
            this.CodigoActiv = _CodigoActiv;
            this.NroCrv = _NroCrv;
            this.NroVal = _NroVal;
            this.CodigoTll = _CodigoTll;
            this.CodigoDiv = _CodigoDiv;
            this.CodigoOT = _CodigoOT;
            this.DescripcionD = _DescripcionD;
            this.UserReg = _UserReg;
        }
    }
}
