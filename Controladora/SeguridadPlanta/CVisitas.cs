using AccesoDatos.NoTransaccional.GestionSeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SeguridadPlanta
{
    public class CVisitas
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new VisitasNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new VisitasNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }
    }
}
