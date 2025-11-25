using AccesoDatos.Transaccional.GestionPersonal.Contabilizacion;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal.Contabilizacion
{
    public class CCostoPlanilla
    {
        public int Insertar(BaseBE oBaseBE)
        {
            return (new CostoPlanillaTAD()).Insertar(oBaseBE);
        }

        public int Eliminar(int CODEMP, int ANOPRC, int MESPRC)
        {
            return (new CostoPlanillaTAD()).Eliminar(CODEMP, ANOPRC, MESPRC);
        }
    }
}
