using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionSeguridadIndustrial;

namespace Controladora.GestionSeguridadIndustrial
{
    public class CCCTT_Sctr
    {
        public DataTable ListarTodos(string IdEntidad, string UserName)
        {
            return new CCTT_SctrNTAD().ListarTodos(IdEntidad, UserName);
        }

        public DataTable DetalleSctr(string IdTipoSCTR, string NroSCTR, string IdSCTR, string UserName)
        {
            return new CCTT_SctrNTAD().DetalleSctr(IdTipoSCTR, NroSCTR, IdSCTR, UserName);
        }
    }
}
