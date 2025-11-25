using AccesoDatos.Transaccional.GestionPersonal.Contabilizacion;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal.Contabilizacion
{
    public class CCBDetalleAD
    {
        public int TanferenciaFinal(BaseBE oBaseBE)
        {
            return (new CBDetalleADTAD()).TanferenciaFinal(oBaseBE);
        }
    }
}
