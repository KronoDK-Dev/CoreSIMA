using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CComprobanteAdicional
    {
        public DataSet ConsultarInfoAdicinalComprobantes(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new ComprobanteAdicionalNTAD()).Consultar(TipoDoc, NroSer, CentroOperativo);
        }
    }
}
