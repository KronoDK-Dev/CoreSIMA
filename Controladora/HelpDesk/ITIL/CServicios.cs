using AccesoDatos.NoTransaccional.HelpDesk.ITIL;
using AccesoDatos.Transaccional.HelpDesk.ITIL;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.ITIL
{
    public class CServicios
    {
    public CServicios() { }

        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new ServiciosNTAD()).Buscar(TextFind, UserName);
        }
        public BaseBE Detalle(string IdServicio, string UserName)
        {
            return (new ServiciosNTAD()).Detalle(IdServicio, UserName);
        }
        public DataTable Listar(string IdServicio, string UserName)
        {
            return (new ServiciosNTAD()).Listar(IdServicio, UserName);
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ServiciosNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarServiciosPorArea(string IdServiciosPadre, string CodigoArea, string Idtipo, string UserName)
        {
            return (new ServiciosNTAD()).ListarServiciosPorArea(IdServiciosPadre, CodigoArea, Idtipo, UserName);
        }
        public DataTable ListarServiciosOtorgadosPorActividad(string IdActividad, string UserName)
        {
            return (new ServiciosNTAD()).ListarServiciosOtorgadosPorActividad(IdActividad, UserName);
        }
        public DataTable ListarRequerimientoPorActividadAtendida(string IdActividad, string IdServicio, string UserName)
        {
            return (new ServiciosNTAD()).ListarRequerimientoPorActividadAtendida(IdActividad, IdServicio, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ServiciosTAD()).ModificaInserta(oBaseBE);
        }
        public DataTable ListarAreas(string IdContacto, string UserName)
        {
            return (new ServiciosNTAD()).ListarAreas(IdContacto, UserName);
        }

     }
}
