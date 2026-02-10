using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class CAutorizaFeriado
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AutorizaFeriadoTAD()).ModificaInserta(oBaseBE);
        }
    }
}
