using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CComprobanteCuota
    {
        public DataSet ConsultarComprobanteCuota(string TipoDoc, string NroSer, int CentroOperativo)
        {
            return (new ComprobanteCuotaNTAD()).Consultar(TipoDoc, NroSer, CentroOperativo);
        }
    }
}
