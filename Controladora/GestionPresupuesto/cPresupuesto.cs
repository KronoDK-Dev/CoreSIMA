using Controladora.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionPresupuesto;

namespace Controladora.GestionPresupuesto
{
    public class cPresupuesto
    {
        public DataTable Listar_Cheques_por_OC_OS(string V_Centro_Operativo, string D_Año, string D_Mes,
            string V_Origen, string UserName)
        {
            return (new OrdenesNTAD()).Listar_Cheques_por_OC_OS(V_Centro_Operativo, D_Año, D_Mes, V_Origen, UserName);
        }
    }
}
