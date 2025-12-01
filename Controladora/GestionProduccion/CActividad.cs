using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CActividad
    {
        public string Modifica(BaseBE oBaseBE)
        {
            return (new ActividadTAD()).Modifica(oBaseBE);
        }

        public string Modifica_cod_atv(BaseBE oBaseBE)
        {
            return (new ActividadTAD()).Modifica_cod_atv(oBaseBE);
        }
    }
}
