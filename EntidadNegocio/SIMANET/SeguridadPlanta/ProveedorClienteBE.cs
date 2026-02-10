using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SIMANET.SeguridadPlanta
{
    public class ProveedorClienteBE:BaseBE
    {
        public int IdTipo { get; set; }
        public string NroRuc { get; set; }
        public string RazonSocial { get; set; }
    }
}
