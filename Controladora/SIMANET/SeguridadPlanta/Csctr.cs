using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class Csctr
    {
        public DataTable ListarTodosAct(int Periodo, int NroProg, string UserName)
        {
            return (new sctrNTAD()).ListarTodosAct(Periodo, NroProg, UserName);
        }
        public DataTable ListarTodos(string IdEntidad, int Periodo, int NroProg, string UserName)
        {
            return (new sctrNTAD()).ListarTodos(IdEntidad, Periodo, NroProg, UserName);
        }
        public string Inserta(BaseBE oBaseBE)
        {
            return (new sctrTAD()).Inserta(oBaseBE);
        }
        public int Eliminar(string IdSCTR,  int IdUsuario, string UserName) {
            return (new sctrTAD()).Eliminar(IdSCTR, IdUsuario, UserName);
        }
    }
}
