using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class ResponsableAreaDetalleBE : BaseBE
    {
        public string IdDetalleResponsableArea { get; set; }
        public string IdInspeccion { get; set; }
        public int IdPersonal { get; set; }
        public DateTime FechaRpta { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaLectura { get; set; }

        public ResponsableAreaDetalleBE() { }
    }
}
