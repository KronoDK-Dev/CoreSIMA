using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CComprobanteDetraccion
    {
        public DataSet ConsultarComprobantesDetraccion(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new ComprobanteDetraccionNTAD()).Consultar(TipoDoc, NroSer, CentroOperativo);
        }
    }
}
