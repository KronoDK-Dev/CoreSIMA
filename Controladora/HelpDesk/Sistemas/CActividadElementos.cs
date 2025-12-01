using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.Sistemas;
using AccesoDatos.Transaccional.HelpDesk.Sistemas;

namespace Controladora.HelpDesk.Sistemas
{
    public class CActividadElementos
    {
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new ActividadElementosNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new ActividadElementosNTAD()).Detalle(Id1, UserName);
        }

        public DataTable Buscar(string TextFind, string IdActividad, string IdTipoElemento, string UserName)
        {
            return (new ActividadElementosNTAD()).Buscar(TextFind, IdActividad, IdTipoElemento, UserName);
        }

        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new ActividadElementosNTAD()).Buscar(TextFind, UserName);
        }

        #region Manetnimiento

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ActividadElementosTAD()).ModificaInserta(oBaseBE);
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new ActividadElementosTAD()).Eliminar(Id1, Id2, Id3);
        }

        #endregion
    }
}
