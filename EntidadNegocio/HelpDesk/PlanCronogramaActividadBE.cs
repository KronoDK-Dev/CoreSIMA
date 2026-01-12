using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class PlanCronogramaActividadBE:BaseBE
    {
        public string IdConogramaActividad { get; set; }
        public string IdConogramaActividadPadre { get; set; }
        public string IdActividad { get; set; }
        public string IdPlan { get; set; }

        public string IdTipoDuracion { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
