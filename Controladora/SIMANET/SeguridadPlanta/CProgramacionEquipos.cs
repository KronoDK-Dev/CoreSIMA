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
    public  class CProgramacionEquipos
    {
        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new ProgramacionEquiposNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }
        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            return (new ProgramacionEquiposNTAD()).Detalle(Id1, Id2, Id3, UserName);
        }
        public string Inserta(BaseBE oBaseBE)
        {
            return (new ProgramacionEquiposTAD()).Inserta(oBaseBE);
        }
        public string Modifica(BaseBE oBaseBE)
        {
            return (new ProgramacionEquiposTAD()).Modifica(oBaseBE);
        }
        public int Eliminar(string Periodo, string IdProgramacion, string IdItem, int IdUsuario, string UserName)
        {
            return (new ProgramacionEquiposTAD()).Eliminar(Periodo, IdProgramacion, IdItem, IdUsuario, UserName);
        }
    }
}
