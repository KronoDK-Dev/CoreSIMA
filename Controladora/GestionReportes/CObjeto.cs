using AccesoDatos.Transaccional.GestionGobernanza;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CObjeto
    {
        public int Insertar(BaseBE oBaseBE)
        {
            return (new ObjetoTAD()).Insertar(oBaseBE);
        }

        public int BackupParam(string Guid, string IdObjeto, string UserName)
        {
            return (new ObjetoTAD()).BackupParam(Guid, IdObjeto, UserName);
        }

        public int EliminaParam(string Guid, string UserName)
        {
            return (new ObjetoTAD()).EliminaParam(Guid, UserName);
        }

        public int BackupConfigParam(string Guid, string IdObjeto, string UserName)
        {
            return (new ObjetoTAD()).BackupConfigParam(Guid, IdObjeto, UserName);
        }

        public string AsignaPadreAdoptivo(int IdObjeto, int IdPadreNuevo, int Orden, string UserName)
        {
            return (new ObjetoTAD()).AsignaPadreAdoptivo(IdObjeto, IdPadreNuevo, Orden, UserName);
        }
    }
}
