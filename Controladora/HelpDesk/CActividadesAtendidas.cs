using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.HelpDesk;

namespace Controladora.HelpDesk
{
    public class CActividadesAtendidas
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ActividadesAtendidasTAD()).ModificaInserta(oBaseBE);
        }
    }
}
