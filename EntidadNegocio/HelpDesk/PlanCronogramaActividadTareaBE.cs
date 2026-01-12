using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class PlanCronogramaActividadTareaBE:BaseBE
    {
        public string IdTarea { get; set; }
        public string IdItemCronograma { get; set; }
        public string IdAccionTarea { get; set; }
        public int Avance{  get; set; }

    }
}
