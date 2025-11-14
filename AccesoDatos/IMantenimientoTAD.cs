using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface IMantenimientoTAD
    {
        int Eliminar();

        int Eliminar(string Id1);

        int Eliminar(string Id1, string Id2);

        int Eliminar(string Id1, string Id2, string Id3);

        int Modificar(BaseBE oBaseBE);

        string Modifica(BaseBE oBaseBE);

        string ModificaInserta(BaseBE oBaseBE);

        int ModificarInsertar(BaseBE oBaseBE);

        int Insertar(BaseBE oBaseBE);

        string Inserta(BaseBE oBaseBE);
    }

}
