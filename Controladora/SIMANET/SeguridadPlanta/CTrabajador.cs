using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public class CTrabajador
    {
        public DataTable TrabajadorInProgramacion(string NroDNI, int Periodo, int IdProgramacion, string UserName)
        {
            return (new TrabajadorNTAD()).TrabajadorInProgramacion(NroDNI, Periodo, IdProgramacion, UserName);
        }

        public DataTable BuscarTrabajador(string FindX, string Criterio, string FechaProgIni, string FechaProgFin, string UserName)
        {
            return (new TrabajadorNTAD()).BuscarTrabajador(FindX, Criterio,  FechaProgIni, FechaProgFin, UserName);
        }
        public DataTable BuscarTrabajadorxDNI(string NroDNI, string UserName)
        {
            return (new TrabajadorNTAD()).BuscarTrabajadorxDNI(NroDNI,  UserName);
        }
      }
}
