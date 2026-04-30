using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public  class CProgramacionPermanencia
    {
        public int ContarIngreso(int Periodo, int NroProg, string UserName)
        {
            return(new ProgramacionPermanenciaNTAD()).ContarIngreso(Periodo, NroProg, UserName);  
        }
    }
}
