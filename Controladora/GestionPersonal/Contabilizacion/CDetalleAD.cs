using AccesoDatos.Transaccional.GestionPersonal.Contabilizacion;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionPersonal.Contabilizacion
{
    public class CDetalleAD
    {
        public int Insertar(BaseBE oBaseBE)
        {
            return (new DetalleADTAD()).Insertar(oBaseBE);
        }
    }
}
