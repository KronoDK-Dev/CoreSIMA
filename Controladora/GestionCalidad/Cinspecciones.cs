using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;

namespace Controladora.GestionCalidad
{
    public class Cinspecciones
    {
        public DataTable BuscarAreaEntidad_Inspeccion(string TextFind, string UserName)
        {
            return (new InspeccionesNTAD()).BuscarAreaEntidad_Inspeccion(TextFind, UserName);
        }
        public DataTable BuscarAreaEntidad(string TextFind, int IdUsuario, string UserName)
        {
            return (new InspeccionesNTAD()).BuscarAreaEntidad(TextFind, IdUsuario, UserName);
        }
        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new InspeccionesNTAD()).Buscar(TextFind, UserName);
        }
        public DataTable ListarTodos(string Id1, int IdUsuario, string UserName)
        {
            return (new InspeccionesNTAD()).ListarTodos(Id1, IdUsuario, UserName);
        }
        public DataTable ListarTodosPorResponsableArea(int IdPersonal, string UserName)
        {
            return (new InspeccionesNTAD()).ListarTodosPorResponsableArea(IdPersonal, UserName);
        }
        public BaseBE Detalle(string Id1, int IdUsuario, string UserName)
        {
            return (new InspeccionesNTAD()).Detalle(Id1, IdUsuario, UserName);
        }

        public string Insertar(BaseBE oBaseBE)
        {
            return (new InspeccionTAD()).InsertarInsoeccion(oBaseBE);
        }

        public int Modificar(BaseBE oBaseBE)
        {
            return (new InspeccionTAD()).Modificar(oBaseBE);
        }

        public int CambiarEstado(string IdInspeccion, int IdEstado, int IdUsuario, string UserName)
        {
            return (new InspeccionTAD()).CambiarEstado(IdInspeccion, IdEstado, IdUsuario, UserName);
        }

        public DataTable ResumenInspeccionesPorEstado(int Año, int IdUsuario, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenInspeccionesPorEstado(Año, IdUsuario, UserName);
        }

        public int BloqueaRI(string IdInspeccion, int Block, string UserName)
        {
            return (new InspeccionTAD()).BloqueaRI(IdInspeccion, Block, UserName);
        }

        #region Reporte resume IP_SIMA

        public DataTable ResumenNoConformeIP_SIMA(int Año, int MesHasta, int IdOrigen, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformeIP_SIMA(Año, MesHasta, IdOrigen, UserName);
        }
        public DataTable ResumenNoConformeIP(int Año, int MesHasta, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformeIP(Año, MesHasta, UserName);
        }
        public DataTable ResumenNoConformeSIMA(int Año, int MesHasta, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformeSIMA(Año, MesHasta, UserName);
        }
        #endregion

        #region Resumen No conformidad por proyecto y IP_SIMA mensual
        public DataTable ResumenNoConformePorProyecto_Mensual(int Año, int MesHasta, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformePorProyecto_Mensual(Año, MesHasta, UserName);
        }
        public DataTable ResumenNoConformePorIP_SIMA_Mensual(int Año, int MesHasta, int IdOrigen, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformePorIP_SIMA_Mensual(Año, MesHasta, IdOrigen, UserName);
        }
        /*Resumen por tipo de insopeccion*/
        public DataTable ResumenNoConformePorTipodeInspeccion(int Año, int MesHasta, string UserName)
        {
            return (new InspeccionesNTAD()).ResumenNoConformePorTipodeInspeccion(Año, MesHasta, UserName);
        }
        #endregion
    }
}
