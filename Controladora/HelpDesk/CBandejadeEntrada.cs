using AccesoDatos.NoTransaccional.HelpDesk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public class CBandejadeEntrada
    {
        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new BandejadeEntradaNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }
        public DataTable ListarRecursoDisponible(string IdRequerimiento,string CodigoArea, int IdUsuario,  string UserName)
        {
            return (new BandejadeEntradaNTAD()).ListarRecursoDisponible(IdRequerimiento,CodigoArea, IdUsuario, UserName);
        }
    }
}
