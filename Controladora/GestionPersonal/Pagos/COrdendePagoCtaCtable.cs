using EntidadNegocio.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal.Pagos;

namespace Controladora.GestionPersonal.Pagos
{
    public class COrdendePagoCtaCtable
    {
        public string Insertar(OrdendePagoCtactableBE oOrdendePagoCtactableBE)
        {
            if ((new OrdendePagoCtaCtableTAD()).Insertar(oOrdendePagoCtactableBE) == 1)
            {
                return (new OrdendePagoCtaCtableTAD()).InsertaTablaFinal().ToString();
            }
            return "1";
        }
    }
}
