using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionContabilidad;

namespace Controladora.GestionContabilidad
{
    public class CCobros
    {
        public DataTable Listar_registro_de_ventas(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_LINEA_NEGOCIO, string V_ORIGEN, string V_SERIE, string V_TIPO_DOCUMENTO, string UserName)
        {
            return (new CobrosNTAD()).Listar_registro_de_ventas(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_CONCEPTO, V_LINEA_NEGOCIO, V_ORIGEN, V_SERIE, V_TIPO_DOCUMENTO, UserName);
        }
    }
}
