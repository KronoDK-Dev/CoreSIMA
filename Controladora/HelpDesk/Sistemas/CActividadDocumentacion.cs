using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.Sistemas;
using AccesoDatos.Transaccional.HelpDesk.Sistemas;

namespace Controladora.HelpDesk.Sistemas
{
    public class CActividadDocumentacion
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ActividadComentarioTAD()).ModificaInserta(oBaseBE);
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new ActividadDocumentacionNTAD()).Detalle(Id1, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string IdPadre, string UserName)
        {
            return (new ActividadDocumentacionNTAD()).ListarTodos(Id1, Id2, IdPadre, UserName);
        }
    }
}
