using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CObjetoReporteCompartido
    {
        public DataTable ListarTodos(int IdObjeto, int IdUsuario, string UserName)
        {
            return (new ObjetoReporteCompartidoNTAD()).ListarTodos(IdObjeto.ToString(), IdUsuario.ToString(), UserName);
        }
        public BaseBE Detalle(int IdObjeto, int IdUsuario, string UserName)
        {
            return (new ObjetoReporteCompartidoNTAD()).Detalle(IdObjeto.ToString(), IdUsuario.ToString(), UserName);
        }
    }
}
