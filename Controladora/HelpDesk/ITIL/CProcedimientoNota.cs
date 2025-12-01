using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.ITIL;
using AccesoDatos.Transaccional.HelpDesk.ITIL;

namespace Controladora.HelpDesk.ITIL
{
    public class CProcedimientoNota
    {
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new ProcedimientoNotaNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            return (new ProcedimientoNotaNTAD()).Detalle(Id1, Id2, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ProcedimientoNotaTAD()).ModificaInserta(oBaseBE);
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new ProcedimientoNotaTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
