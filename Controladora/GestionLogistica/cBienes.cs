using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cBienes
    {
        public DataTable Listar_BienesAlmacenados(string V_CLASE_MATERIAL, string D_FECHA_ALMACENAMIENTO_inicial,
            string D_FECHA_ALMACENAMIENTO_fina, string UserName)
        {
            return (new BienesNTAD()).Listar_BienesAlmacenados(V_CLASE_MATERIAL, D_FECHA_ALMACENAMIENTO_inicial,
                D_FECHA_ALMACENAMIENTO_fina, UserName);
        }
    }
}
