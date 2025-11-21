using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CComprobanteDetalle
    {
        public DataSet ConsultarComprobantesDetalle(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new ComprobanteDetalleNTAD()).Consultar(TipoDoc, NroSer, CentroOperativo);
        }
    }
}
