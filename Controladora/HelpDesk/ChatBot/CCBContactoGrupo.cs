using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.ChatBot;
using AccesoDatos.Transaccional.HelpDesk.ChatBot;

namespace Controladora.HelpDesk.ChatBot
{
    public class CCBContactoGrupo
    {
        public DataTable DetalleContacto(string CodPersonal, string UserName)
        {
            return (new CBContactoGrupoNTAD()).DetalleContacto(CodPersonal, UserName);
        }

        public BaseBE DetalleContactoxID(int IdContacto, string UserName)
        {
            return (new CBContactoGrupoNTAD()).DetalleContactoxID(IdContacto, UserName);
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new CBContactoGrupoNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable ListarTodos(int IdContacto, string UserName)
        {
            return (new CBContactoGrupoNTAD()).ListarTodos(IdContacto, UserName);
        }

        public DataTable IsMiembrodeGrupo(int IdContactGrupo, string CodPersonal, string UserName)
        {
            return (new CBContactoGrupoNTAD()).IsMiembrodeGrupo(IdContactGrupo, CodPersonal, UserName);
        }

        public DataTable LstContactSendtoGrupo(int IdContactGrupo, string UserName)
        {
            return (new CBContactoGrupoNTAD()).LstContactSendtoGrupo(IdContactGrupo, UserName);
        }

        public string Insertar(BaseBE oBaseBE)
        {
            return (new CBContactoGrupoTAD()).Inserta(oBaseBE);
        }

        public string ActualizaEstado(string CodPersonal, int IdEstado, string UserName)
        {
            return (new CBContactoGrupoTAD()).ActualizaEstado(CodPersonal, IdEstado, UserName);
        }
    }
}
