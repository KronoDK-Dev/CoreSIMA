using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;
using EntidadNegocio;
using EntidadNegocio.GestionCalidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionCalidad
{
    public  class CResponsableAreaDetalle
    {
        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ResponsableAreaDetalleTAD()).ModificarInsertar(oBaseBE);
        }

        public int ActualizaEstado(BaseBE oBaseBE) {
            return (new ResponsableAreaDetalleTAD()).ActualizaEstado(oBaseBE);
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        { 
            return (new ResponsableAreaDetalleNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new ResponsableAreaDetalleNTAD()).Detalle(Id1,UserName);
        }
    }
}
