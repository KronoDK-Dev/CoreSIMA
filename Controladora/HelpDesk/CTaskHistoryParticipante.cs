using AccesoDatos.Transaccional.HelpDesk;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public class CTaskHistoryParticipante
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new TaskHistoryParticipanteTAD()).ModificaInserta(oBaseBE);
        }
        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new TaskHistoryParticipanteTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
