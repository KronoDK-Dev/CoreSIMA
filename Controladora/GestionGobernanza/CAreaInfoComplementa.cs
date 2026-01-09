using AccesoDatos.Transaccional.GestionGobernanza;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
