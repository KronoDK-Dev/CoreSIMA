using AccesoDatos.NoTransaccional.HelpDesk.ITIL;
using AccesoDatos.Transaccional.HelpDesk.ITIL;
using EntidadNegocio;
using EntidadNegocio.HelpDesk.ITIL;
using System.Data;

namespace Controladora.HelpDesk.ITIL
{
    public  class CProcedimiento
    {
        public CProcedimiento() { }
        public string ModificarInserta(BaseBE oBaseBE)
        { 
            ProcedimientoBE oProcedimientoBE = (ProcedimientoBE)oBaseBE;
            if (oProcedimientoBE.IdAccion == "0")
            {
                return (new ProcedimientoTAD()).Inserta(oBaseBE);
            }
            else
            {
                return (new ProcedimientoTAD()).Modifica(oBaseBE);
            }
        }
        public int Eliminar(string Id1, int IdUsuario,string Id2)
        {
            return (new ProcedimientoTAD()).Eliminar(Id1, IdUsuario.ToString(), Id2);
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new ProcedimientoNTAD()).ListarTodos(Id1, Id2, UserName);
        }
    }
}
