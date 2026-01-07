using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public  class PlandeTrabajoBE:BaseBE
    {
        public string IdPlan{ get; set; }
        public string Nombre { get; set; }
        public string IdServicioArea { get; set; }
        public int IdPersonalAtencion { get; set; }
        public string IdResponsableAtencion { get; set; }
        public string ApellidosyNombres { get; set; }
        public string NroDNI{ get; set; }
        public int IdTipo { get; set; }
        public string IdRequerimiento { get; set; }

        public int Avance { get; set; }

    }
}
