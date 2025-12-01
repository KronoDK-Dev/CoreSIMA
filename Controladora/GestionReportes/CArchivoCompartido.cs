using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionReportes;
using AccesoDatos.Transaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CArchivoCompartido
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ArchivoCompartidoNTAD()).ListarTodos(Id1, UserName);
        }
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ArchivoCompartidoTAD()).ModificaInserta(oBaseBE);
        }
    }
}
