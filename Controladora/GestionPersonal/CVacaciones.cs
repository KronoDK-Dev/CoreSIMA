using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal;

namespace Controladora.GestionPersonal
{
    public class CVacaciones
    {
        public int Insertar(BaseBE oBaseBE)
        {
            return (new VacacionesTAD()).Insertar(oBaseBE);
        }

        public int Eliminar(BaseBE oBaseBE)
        {
            return (new VacacionesTAD()).Eliminar(oBaseBE);
        }
    }
}
