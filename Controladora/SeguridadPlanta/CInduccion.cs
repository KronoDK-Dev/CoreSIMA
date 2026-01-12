using AccesoDatos.Transaccional.SeguridadPlanta;
using EntidadNegocio.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SeguridadPlanta
{
    public  class CInduccion
    {
        public string ModificaInsertar(personal opersonal)
        {
            return (new InduccionTAD()).ModificaInsertar(opersonal);
        }

    }
}
