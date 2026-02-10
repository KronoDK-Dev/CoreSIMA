using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public class CProveedorCliente
    {
        public int Insertar(BaseBE oBaseBE)
        {
            return (new ProveedorClienteTAD()).Insertar(oBaseBE);
        }
    }
}
