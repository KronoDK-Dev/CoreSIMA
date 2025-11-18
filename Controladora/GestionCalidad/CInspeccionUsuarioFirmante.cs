using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionCalidad
{
    public  class CInspeccionUsuarioFirmante
    {
        public string ModificaInsertaXTipoFirmante(BaseBE oBaseBE)
        {
            return (new InspeccionUsuarioFirmanteTAD()).ModificaInsertaXTipoFirmante(oBaseBE);
        }
        
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new InspeccionUsuarioFirmanteTAD()).ModificaInserta(oBaseBE);
        }

        public int Eliminar(string IdInspeccion, string IdUsuarioFirmante, int IdEsatdo, int IdUsuario, string UserName)
        {
            return (new InspeccionUsuarioFirmanteTAD()).Eliminar(IdInspeccion, IdUsuarioFirmante, IdEsatdo, IdUsuario, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new InspeccionUsuarioFirmanteNTAD()).ListarTodos(Id1, Id2, UserName);
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new InspeccionUsuarioFirmanteNTAD()).ListarTodos(Id1, UserName);

        }
        public int ActualizaNroMsgRecibidos(BaseBE oBaseBE)
        {
            return (new InspeccionUsuarioFirmanteTAD()).ActualizaNroMsgRecibidos(oBaseBE);
        }

        public int FirmaAprobarFromEMail(BaseBE oBaseBE)
        {
            return (new InspeccionUsuarioFirmanteTAD()).FirmaAprobarFromEMail(oBaseBE);
        }

        public DataTable ListarSolicitudAprobacion(int IdUsuario, string UserName)
        {
            return (new InspeccionUsuarioFirmanteNTAD()).ListarSolicitudAprobacion(IdUsuario, UserName);
        }

        public string ModificaInsertaFirma(BaseBE oBaseBE)
        {
            return (new InspeccionUsuarioFirmanteTAD()).ModificaInsertaFirma(oBaseBE);
        }

        public DataTable Buscar(string TextFind, string UserName)
        { 
            return (new InspeccionUsuarioFirmanteNTAD()).Buscar(TextFind, UserName);
        }
     }
}
