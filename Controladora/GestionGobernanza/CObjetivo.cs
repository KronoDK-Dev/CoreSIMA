using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionGobernanza;

namespace Controladora.GestionGobernanza
{
    public class CObjetivo
    {
        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ObjetivoTAD()).ModificarInsertar(oBaseBE);
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new ObjetivoTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
