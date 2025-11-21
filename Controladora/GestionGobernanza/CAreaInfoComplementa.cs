using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionGobernanza;

namespace Controladora.GestionGobernanza
{
    public class CAreaInfoComplementa
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new AreaInfoComplementaTAD()).ModificaInserta(oBaseBE);
        }
    }
}
