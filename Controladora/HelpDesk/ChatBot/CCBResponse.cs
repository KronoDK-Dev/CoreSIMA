using AccesoDatos.NoTransaccional.HelpDesk.ChatBot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.ChatBot
{
    public class CCBResponse
    {
        public DataTable Buscar(string TextFind, string UserName) {
            return (new CBResponseNTAD()).Buscar(TextFind, UserName);
        }
        public DataTable ListarTodos(string Id1, string UserName) {
            return (new CBResponseNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new CBResponseNTAD()).ListarTodos(Id1, Id2, UserName);
        }
        public DataTable ListarAplicaciones(int IdTipo, string UserName)
        {
            return (new CBResponseNTAD()).ListarAplicaciones(IdTipo, UserName);
        }


     }
}
