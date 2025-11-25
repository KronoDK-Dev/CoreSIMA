using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal;

namespace Controladora.GestionPersonal
{
    public class CDatosFijos
    {
        public int Modificar(BaseBE oBaseBE)
        {
            return (new DatosFijosTAD()).Modificar(oBaseBE);
        }
    }
}
