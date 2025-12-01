using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;

namespace Controladora.HelpDesk
{
    public class CFileRequerimiento
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new FileRequerimientoNTAD()).ListarTodos(Id1, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ArchivoAdjuntoTAD()).ModificaInserta(oBaseBE);
        }
    }
}
