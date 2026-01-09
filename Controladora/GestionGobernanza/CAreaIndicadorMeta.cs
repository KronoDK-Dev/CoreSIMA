using AccesoDatos.NoTransaccional.GestionGobernanza;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionGobernanza
{
    public  class CAreaIndicadorMeta
    {
        public DataTable ListarMetasPorAreaIndicador(string IdAreaComple, string IdIndicador, string Periodo, string UserName)
        {
            return (new AreaIndicadorMetaNTAD()).ListarMetasPorAreaIndicador(IdAreaComple, IdIndicador, Periodo, UserName);
        }
     }
}
