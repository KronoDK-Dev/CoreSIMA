using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;

namespace Controladora.GestionCalidad
{
    public class CProyectoActividad
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ProyectoActividadNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new ProyectoActividadNTAD()).Buscar(TextFind, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ProyectoActividadTAD()).ModificaInserta(oBaseBE);
        }
    }
}
