using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class TaskHistoryParticipanteBE : BaseBE
    {
        public string IdParticipante { get; set; }
        public int IdPersonal { get; set; }
        public string IdHistory { get; set; }
    }
}
