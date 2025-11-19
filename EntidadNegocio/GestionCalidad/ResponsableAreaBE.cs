using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class ResponsableAreaBE : BaseBE
    {
        public string IdInspeccion { get; set; }
        public string IdPersonal { get; set; }
        public int IdTipoPersonal { get; set; }

        public ResponsableAreaBE()
        {
        }

        public ResponsableAreaBE(string _IdInspeccion, string _IdPersonal)
        {
            this.IdInspeccion = _IdInspeccion;
            this.IdPersonal = _IdPersonal;
        }
    }
}
