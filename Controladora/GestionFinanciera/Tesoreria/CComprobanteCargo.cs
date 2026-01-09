using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CComprobanteCargo
    {
        public DataSet ConsultarComprobantesCargo(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new ComprobanteCargoNTAD()).ListarTodos(TipoDoc, NroSer, CentroOperativo);
        }
    }
}
