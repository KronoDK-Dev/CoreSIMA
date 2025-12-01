using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionProduccion
{
    public class OtBE : BaseBE
    {
        public int CodigoOT { get; set; }
        public string CodigoDiv { get; set; }
        public int NroVal { get; set; }
        public string CodigoTll { get; set; }
        public string DescripcionD { get; set; }
        public string UserReg { get; set; }

        public OtBE()
        {

        }

        public OtBE(int _CodigoOT, int _NroVal, string _CodigoDiv, string _CodigoTll, string _DescripcionD, string _UserReg)
        {
            this.CodigoOT = _CodigoOT;
            this.CodigoDiv = _CodigoDiv;
            this.NroVal = _NroVal;
            this.CodigoTll = _CodigoTll;
            this.DescripcionD = _DescripcionD;
            this.UserReg = _UserReg;
        }
    }
}
