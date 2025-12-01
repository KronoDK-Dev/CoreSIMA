using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk;
using AccesoDatos.Transaccional.HelpDesk;
using EntidadNegocio;

namespace Controladora.HelpDesk
{
    public class CRequermiento
    {
        public DataTable ListarTodosInMsg(int IdContacto, string UserName)
        {
            return (new RequerimientoNTAD()).ListarTodosInMsg(IdContacto, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new RequerimientoNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            return (new RequerimientoNTAD()).Detalle(Id1, Id2, UserName);
        }

        public DataTable ListarTodosAttach(string IdRequerimiento, string UserName)
        {
            return (new RequerimientoNTAD()).ListarTodosAttach(IdRequerimiento, UserName);
        }

        public string ModificaInserta(BaseBE oRequerimientoBE)
        {
            string IdRqr = (new RequerimientoTAD()).ModificaInserta(oRequerimientoBE);
            /*if (IdRqr != "-1") {
                foreach (AprobadorBE oAprobadorBE in oLstAprobadoresBE) {
                    (new AprobadorTAD()).ModificaInserta(oAprobadorBE);
                }
                foreach (ArchivoAdjuntoBE oArchivoAdjuntoBE in oLstArchivoAdjuntoBE)
                {
                    (new ArchivoAdjuntoTAD()).ModificaInserta(oArchivoAdjuntoBE);
                }

            }*/
            return IdRqr;
        }

        public string CambiarEstado(BaseBE oBaseBE)
        {
            return (new RequerimientoTAD()).Modifica(oBaseBE);
        }

        public string EnviaSolAprobServicio(string IdRequerimiento, string Token, int IdEstado, int IdUsuario, string UserName)
        {
            return (new RequerimientoTAD()).EnviaSolAprobServicio(IdRequerimiento, Token, IdEstado, IdUsuario, UserName);
        }
    }
}
