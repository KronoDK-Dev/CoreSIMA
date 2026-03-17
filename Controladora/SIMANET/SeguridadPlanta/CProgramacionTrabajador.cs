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
        public int Eliminar(BaseBE oBaseBE)
        {
            return (new ProgramacionTrabajadorTAD()).Eliminar(oBaseBE);
        }
        public string Reprogramar(BaseBE oBaseBE)
        {
            return (new ProgramacionTrabajadorTAD()).Reprogramar(oBaseBE);
        }
        public BaseBE ReprogramacionDetalleTrabajador(string Id1, string Id2, string Id3, string UserName)
        {
            return (new ProgramacionTrabajadorNTAD()).Detalle(Id1, Id2, Id3, UserName);
        }
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
