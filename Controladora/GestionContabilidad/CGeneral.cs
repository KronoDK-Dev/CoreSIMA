using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class CGeneral
    {
        public DataTable Listar_centros_de_costo(string V_CENTRO_OPERATIVO, string V_GRUPO_CC_DESDE, string V_GRUPO_CC_HASTA, string UserName)
        {
            return (new GeneralNTAD()).Listar_centros_de_costo(V_CENTRO_OPERATIVO, V_GRUPO_CC_DESDE, V_GRUPO_CC_HASTA, UserName);
        }

        public DataTable Listar_tipo_de_cambio(string V_ANIO, string V_CODMND, string V_MESFIN, string V_MESINI, string UserName)
        {
            return (new GeneralNTAD()).Listar_tipo_de_cambio(V_ANIO, V_CODMND, V_MESFIN, V_MESINI, UserName);
        }
    }
}
