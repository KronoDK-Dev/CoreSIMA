using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorException
{
    public class SIMAExcepcion : ApplicationException
    {
        protected string error;
        protected string mensaje;

        public string Error => this.error;

        public string Mensaje => this.mensaje;

        public SIMAExcepcion(string error)
            : base(error)
        {
            this.error = error;
        }

        public SIMAExcepcion(string error, string mensaje)
            : base(error)
        {
            this.error = error;
            this.mensaje = mensaje;
        }
    }
}
