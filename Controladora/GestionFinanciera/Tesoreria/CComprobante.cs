using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using AccesoDatos.Transaccional.GestionFinanciera.Tesoreria;
using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public  class CComprobante
    {
        public CComprobante() { }

        public DataSet ConsultarComprobantes(string Ind_Org, int CentroOperativo)
        {
            return (new ComprobanteNTAD()).Consultar(Ind_Org, CentroOperativo);
        }
        public DataSet ConsultarComprobatesPorEstado(string Ind_Org, int IdEstado, int CentroOperativo)
        {
            return (new ComprobanteNTAD()).ConsultarPorEstado(Ind_Org, IdEstado, CentroOperativo);
        }
        public DataSet ConsultarComprobantesXNro(string Ind_Org, int idEstado, string TipoDoc, string NroSerie, int CentroOperativo)
        {
            return (new ComprobanteNTAD()).Consultar(Ind_Org, idEstado, TipoDoc, NroSerie, CentroOperativo);
        }

        public int ActualizarEstadoComprobante(string TipoDoc, string NroSer, int Estado, int CentroOperativo)
        {
            return (new ComprobanteTAD()).ActualizarEstado(TipoDoc, NroSer, Estado, CentroOperativo);
        }
    }
}
