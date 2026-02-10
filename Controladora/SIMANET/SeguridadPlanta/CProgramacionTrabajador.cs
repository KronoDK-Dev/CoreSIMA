using AccesoDatos.NoTransaccional.SIMANET.SeguridadPlanta;
using AccesoDatos.Transaccional.SIMANET.SeguridadPlanta;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SIMANET.SeguridadPlanta
{
    public class CProgramacionTrabajador
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ProgramacionTrabajadorTAD()).ModificaInserta(oBaseBE);
        }
        public DataTable ListarTodos(string IdProgramacion , string Periodo, string NroDNI, string UserName)
        {
            return (new ProgramacionTrabajadorNTAD()).ListarTodos(IdProgramacion,  Periodo, NroDNI, UserName);
        }
        public DataTable ListarValidaSCTREXAM(string NroDNI, string UserName)
        {
            return (new ProgramacionTrabajadorNTAD()).ListarValidaSCTREXAM(NroDNI, UserName);
        }
    }
}
