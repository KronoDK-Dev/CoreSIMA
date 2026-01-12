using AccesoDatos.NoTransaccional.General;
using AccesoDatos.Transaccional.General;
using AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria;
using AccesoDatos.Transaccional.GestionFinanciera.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionFinanciera.Tesoreria
{
    public class CControl
    {
        public DataSet VerificaFacturaNueva(string Fec_Ope, int CentroOperativo)
        {
            return (new ControlNTAD()).VerificaDocNew(Fec_Ope, CentroOperativo);
        }
        public int ActualizarTablaControl(string Ind_Org, string Fec_Ope, int Flg_Accion, int CentroOperativo)
        {
            return (new ControlTAD()).Actualizar(Ind_Org, Fec_Ope, Flg_Accion, CentroOperativo);
        }
    }
}
