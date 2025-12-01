using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.HelpDesk;

namespace Controladora.HelpDesk
{
    public class CPlanCronogramaActividadTarea
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new PlanCronogramaActividadTareaTAD()).ModificaInserta(oBaseBE);
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new PlanCronogramaActividadTareaTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
