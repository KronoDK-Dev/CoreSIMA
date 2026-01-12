using AccesoDatos.NoTransaccional.HelpDesk.Sistemas;
using AccesoDatos.Transaccional.HelpDesk.Sistemas;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.Sistemas
{
    public  class CSistemaProcesoSubProceso
    {
        public int Eliminar(string Id1, string Id2, string Id3)
        {
            return (new SistemaProcesoSubProcesoTAD()).Eliminar(Id1, Id2, Id3);
        }
        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new SistemaProcesoSubProcesoNTAD()).Detalle(Id1, UserName);
        }
        public DataTable Listar(string IdSistema, string UserName)
        {
            return (new SistemaProcesoSubProcesoNTAD()).Listar(IdSistema, UserName);
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new SistemaProcesoSubProcesoNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarActividadesAtendidasXRequerimiento(int IdPersonalAtencion, string IdRequerimiento,int IdPersonalRequerimiento, string UserName)
        {
            return (new SistemaProcesoSubProcesoNTAD()).ListarActividadesAtendidasXRequerimiento(IdPersonalAtencion, IdRequerimiento, IdPersonalRequerimiento, UserName);
        }
        #region Mantenimiento
            public string ModificaInserta(BaseBE oBaseBE)
            {
                return (new SistemaProcesoSubProcesoTAD()).ModificaInserta(oBaseBE);
            }
        #endregion
        }
}
