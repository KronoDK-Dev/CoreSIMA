using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionFinanciera.Tesoreria
{
    public class ComprobanteRetencionNTAD : BaseAD
    {
        public DataSet Consultar(string Ind_Org, int CentroOperativo)
        {
            try
            {
                return (new ComprobanteNTAD()).Consultar(Ind_Org, CentroOperativo);
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                ;
            }
            catch (System.Data.OleDb.OleDbException oleDbException)
            {
                ;
            }

            catch (Exception ex)
            {
                ;
            }

            return null;
        }
    }
}
