using AccesoDatos.Transaccional.SIMANET;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class CCsctrDetalle
    {
        public string Inserta(BaseBE oBaseBE)
        {
            return (new sctrDetalleTAD()).Inserta(oBaseBE);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new sctrDetalleTAD()).ModificaInserta(oBaseBE);
        }
    }
}
