using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.HelpDesk.ITIL;
using AccesoDatos.Transaccional.HelpDesk.ITIL;

namespace Controladora.HelpDesk.ITIL
{
    public class CServicios
    {
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

        public DataTable ListarAreasXServicio(string IdServProd, string UserName)
        {
            return (new ServiciosNTAD()).ListarAreasXServicio(IdServProd, UserName);
        }

        public DataTable ListarActvXServicio(string IdServProd, string UserName)
        {
            return (new ServiciosNTAD()).ListarActvXServicio(IdServProd, UserName);
        }

        public DataTable ListarRespxServicio(string IdServProd, string UserName)
        {
            return (new ServiciosNTAD()).ListarRespxServicio(IdServProd, UserName);
        }

        public DataTable ListarActvChck(string IdSistemaPadre, string IdServProd, string UserName)
        {
            return (new ServiciosNTAD()).ListarActvChck(IdSistemaPadre, IdServProd, UserName);
        }

        public string AsignarActividad(BaseBE oBaseBE)
        {
            return (new ServiciosTAD()).AsignarActividad(oBaseBE);
        }

        public string ServicioArea(BaseBE oBaseBE)
        {
            return (new ServiciosTAD()).ServicioArea(oBaseBE);
        }

        public string ServicioResponsable(BaseBE oBaseBE)
        {
            return (new ServiciosTAD()).ServicioResponsable(oBaseBE);
        }
    }
}
