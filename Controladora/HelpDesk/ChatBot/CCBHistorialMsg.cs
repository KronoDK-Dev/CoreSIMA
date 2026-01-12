using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.ChatBot;
namespace Controladora.HelpDesk.ChatBot
{
    public  class CCBHistorialMsg
    {
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new CBHistorialMsgNTAD()).ListarTodos(Id1, Id2, UserName);
        }
        public DataTable ListarChatContenido(string IdMsg, string UserName)
        {
            return (new CBHistorialMsgNTAD()).ListarChatContenido(IdMsg,UserName);
        }
        public DataTable LstHistorialDialogoContenidoLikes(string IdContents, string UserName)
        {
            return (new CBHistorialMsgNTAD()).LstHistorialDialogoContenidoLikes(IdContents, UserName);
        }
    }
}
