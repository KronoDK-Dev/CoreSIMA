using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cGeneral
    {
        public DataTable Listar_TG_EQUIVALENICIASGENERICAS(string UserName)
        {
            return (new GeneralNTAD()).Listar_TG_EQUIVALENICIASGENERICAS(UserName);
        }

        public DataTable Listar_TG_EQUIVALENICIASPORMATERIA(string UserName)
        {
            return (new GeneralNTAD()).Listar_TG_EQUIVALENICIASPORMATERIA(UserName);
        }

        public DataTable Listar_Tg_Unidad_Medida(string UserName)
        {
            return (new GeneralNTAD()).Listar_Tg_Unidad_Medida(UserName);
        }

        public DataTable Listar_Tg_Unidad_Medida2(string unidad, string UserName)
        {
            return (new GeneralNTAD()).Listar_Tg_Unidad_Medida2(unidad, UserName);
        }
    }
}
