using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{
    public class CBalance
    {
        public DataTable Listar_comparventvscostoproyecotR(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PERIODO, string V_PROYECTO, string UserName)
        {
            return (new BalanceNTAD()).Listar_comparventvscostoproyecotR(V_CENTRO_OPERATIVO, V_DIVISION, V_PERIODO, V_PROYECTO, UserName);
        }

        public DataTable Listar_comparventvscostoproyec_ot(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PERIODO, string V_PROYECTO, string UserName)
        {
            return (new BalanceNTAD()).Listar_comparventvscostoproyec_ot(V_CENTRO_OPERATIVO, V_DIVISION, V_PERIODO, V_PROYECTO, UserName);
        }
    }
}
