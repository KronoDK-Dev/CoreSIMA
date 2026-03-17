using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class CCalendario
    {
        public DataTable ListaCalendarioLaboral(string NroDNI, string Año, string Mes, string UserName) {
            return (new CalendarioNTAD()).ListaCalendarioLaboral(NroDNI, Año, Mes, UserName);
        }
    }
}
