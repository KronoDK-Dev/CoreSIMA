using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorException
{
    public class SIMAExcepcionIU : SIMAExcepcion
    {
        public SIMAExcepcionIU(string error)
            : base(error)
        {
            this.error = error;
        }

        public SIMAExcepcionIU(string error, string mensaje)
            : base(error, mensaje)
        {
            this.error = error;
            this.mensaje = mensaje;
        }
    }
}
