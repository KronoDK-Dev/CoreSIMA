using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionCalidad
{
    public class CInspeccionAnexo
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new InspeccionAnexoNTAD()).ListarTodos(Id1, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new InspeccionAnexoTAD()).ModificaInserta(oBaseBE);
        }
    }
}
