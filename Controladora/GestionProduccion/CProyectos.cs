using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;
using AccesoDatos.Transaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CProyectos
    {
        public DataTable Buscar(int IdTipoBusqueda, string TextFind, string UserName)
        {
            return (new ProyectosNTAD()).Buscar(IdTipoBusqueda, TextFind, UserName);
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new ProyectosNTAD()).Detalle(Id1, UserName);
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ProyectosNTAD()).ListarTodos(Id1, UserName);
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ProyectosTAD()).ModificarInsertar(oBaseBE);
        }
    }
}
