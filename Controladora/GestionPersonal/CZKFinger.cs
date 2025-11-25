using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionPersonal;

namespace Controladora.GestionPersonal
{
    public class CZKFinger
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ZKFingerTAD()).ModificaInserta(oBaseBE);
        }
    }
}
