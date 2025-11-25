using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cRequerimientos
    {
        public DataTable Listar_Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            return (new RequerimientosNTAD()).Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);
        }
    }
}
