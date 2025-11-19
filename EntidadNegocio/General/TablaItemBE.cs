using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.General
{
    public class TablaItemBE : BaseBE
    {
        public int IdTabla { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public TablaItemBE(){}
    }
}
