using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionCostos;

namespace Controladora.GestionCostos
{
    public class CVentas
    {
        public DataTable Listar_Ventas_diferidas_x_OT_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO, string V_DIVISION, string UserName)
        {
            return (new VentasNTAD()).Listar_Ventas_diferidas_x_OT_detalle(V_PERIODO, V_CENTRO_OPERATIVO, V_DIVISION, UserName);
        }

        public DataTable Listar_Ventas_diferidas_x_Doc_detalle(string V_PERIODO, string V_CENTRO_OPERATIVO, string V_DIVISION, string UserName)
        {
            return (new VentasNTAD()).Listar_Ventas_diferidas_x_OT_detalle(V_PERIODO, V_CENTRO_OPERATIVO, V_DIVISION, UserName);
        }
    }
}
