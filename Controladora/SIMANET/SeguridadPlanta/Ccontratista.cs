using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using Controladora.Seguridad;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class Ccontratista
    {
        public BaseBE Detalle(int NroProgramacion, int Periodo, int IdUsuario, int IdTipoProgramacion, string UserName)
        {
            return (new ContratistaNTAD()).Detalle(NroProgramacion, Periodo, IdUsuario, IdTipoProgramacion, UserName);
        }
        public DataTable ListarTodos(int NroProgramacion, int Periodo, int IdUsuario, int IdTipoProgramacion, string UserName)
        {
            return (new ContratistaNTAD()).ListarTodos(NroProgramacion, Periodo, IdUsuario, IdTipoProgramacion, UserName);
        }
        public DataTable BuscarPersonalSIMA(string Nombres, string UserName)
        {
            return (new ContratistaNTAD()).BuscarPersonalSIMA(Nombres, UserName);
        }
        public DataTable BuscarAreaSIMA(int idCentroOperativo, string NombresArea, string UserName)
        {
            return (new ContratistaNTAD()).BuscarAreaSIMA(idCentroOperativo, NombresArea, UserName);
        }



        public string Insertar(BaseBE oBaseBE)
        {
            return (new ContratistaTAD()).Inserta(oBaseBE);
        }
        public string Modificar(BaseBE oBaseBE) {
            return (new ContratistaTAD()).Modifica(oBaseBE);
        }

        public int Eliminar(int Periodo, int IdProgramacion, int IdUsuario, string UserName)
        {
            return (new ContratistaTAD()).Eliminar(Periodo, IdProgramacion, IdUsuario, UserName);
        }
    }
}
