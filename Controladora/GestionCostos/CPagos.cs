using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCostos;

namespace Controladora.GestionCostos
{
    public class CPagos
    {
        public DataTable Listar_analisis_gastos_ccnatudet(string D_AÑO_DE_PROCESO, string D_MES_DE_PROCESO, string V_CENTRO_OPERATIVO, string V_CUENTA_MAYOR, string UserName)
        {
            return (new PagosNTAD()).Listar_analisis_gastos_ccnatudet(D_AÑO_DE_PROCESO, D_MES_DE_PROCESO, V_CENTRO_OPERATIVO, V_CUENTA_MAYOR, UserName);
        }
        public DataTable Listar_analisis_gast_itemsasient(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            return (new PagosNTAD()).Listar_analisis_gast_itemsasient(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT, UserName);
        }
    }
}
