using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionFinanciera.Tesoreria.Pagos
{
    public  class LecturaError
    {
        public LecturaError() { }   

      public string tipo { get; set; }
      public int?  linea { get; set; }
      public int? posicion { get; set; }
      public string mensaje { get; set; }
    }
}
