using Controladora.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class COrdenes
    {
        public DataTable Listar_detalle_gasto_pry_ot_oses(string N_CEO, string V_CODDIV, string V_CODPRY, string V_NROOTS, string UserName)
        {
            return (new OrdenesNTAD()).Listar_detalle_gasto_pry_ot_oses(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS, UserName);
        }

        public DataTable Listar_det_gasto_pry_ot_ocosu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_NROOTS, string V_PROYECTO, string V_ANIO, string UserName)
        {
            return (new OrdenesNTAD()).Listar_det_gasto_pry_ot_ocosu(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_NROOTS, V_PROYECTO, V_ANIO, UserName);
        }

        public DataTable Listar_ot_ocompra(string D_FECHA_INICIO, string D_FECHA_FIN, string V_DIVISION, string UserName)
        {
            return (new OrdenesNTAD()).Listar_ot_ocompra(D_FECHA_INICIO, D_FECHA_FIN, V_DIVISION, UserName);
        }
    }
}
