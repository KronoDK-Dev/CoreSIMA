using EntidadNegocio.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal.Pagos;

namespace Controladora.GestionPersonal.Pagos
{
    public class COrdendePago
    {
        public string Insertar(OrdendePagoBE oOrdendePagoBE)
        {
            return (new OrdendePagoTAD()).Insertar(oOrdendePagoBE).ToString();
        }
    }
}
