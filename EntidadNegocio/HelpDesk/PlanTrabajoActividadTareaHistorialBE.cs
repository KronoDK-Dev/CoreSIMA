using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class PlanTrabajoActividadTareaHistorialBE : BaseBE
    {
        public PlanTrabajoActividadTareaHistorialBE() { }
        public string IdHistorial { get; set; }
        public string IdTarea { get; set; }

        public string Nombre { get; set; }
        public int IdTipoAccion { get; set; }
        public int IdTipoTiempo { get; set; }
        public double valTipoTime { get; set; }
    }
}
