using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SeguridadPlanta
{
    public  class MensajeResultBE
    {
        public MensajeResultBE() { }
        public bool status{ get; set; }
        public string message { get; set; }
        public data data { get; set; }
    }
}
