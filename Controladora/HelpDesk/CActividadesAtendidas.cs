using AccesoDatos.Transaccional.HelpDesk;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk
{
    public  class CActividadesAtendidas
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ActividadesAtendidasTAD()).ModificaInserta(oBaseBE);
        }
    }
}
