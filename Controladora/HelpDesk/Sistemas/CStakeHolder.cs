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
    public  class CStakeHolder
    {
        public BaseBE Detalle(string Id1, string UserName)
        {
            return (new StakeHolderNTAD()).Detalle(Id1, UserName);
        }
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new StakeHolderNTAD()).ListarTodos(Id1, Id2, UserName);
        }
        /*Mantenimienti*/
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new StakeHolderTAD()).ModificaInserta(oBaseBE);
        }
        public int Eliminar(string Id1, string Id2, string Id3) { 
            return (new StakeHolderTAD()).Eliminar(Id1, Id2, Id3);
        }
    }
}
