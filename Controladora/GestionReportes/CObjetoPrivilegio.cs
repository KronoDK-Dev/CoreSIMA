using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CObjetoPrivilegio
    {
        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ObjetoPrivilegioTAD()).ModificaInserta(oBaseBE);
        }

        public DataTable ListaAccesos_RptxUsuario(string s_usuario, string sAmbiente, string UserName)
        {
            return (new ObjetoPrivilegioTAD()).ListaAccesos_RptxUsuario(s_usuario, sAmbiente, UserName);

        }

        public DataTable ListaAccesos_RptxUsuario_v2(string s_usuario, string UserName)
        {
            return (new ObjetoPrivilegioTAD()).ListaAccesos_RptxUsuario_v2(s_usuario, UserName);
        }
    }
}
