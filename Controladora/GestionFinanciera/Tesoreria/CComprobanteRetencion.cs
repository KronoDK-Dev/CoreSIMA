using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CComprobanteRetencion
    {
        public DataSet ConsultarComprobantedeRetencion(string Ind_Org, int CentroOperativo)
        {
            return (new ComprobanteRetencionNTAD()).Consultar(Ind_Org, CentroOperativo);
        }
    }
}
