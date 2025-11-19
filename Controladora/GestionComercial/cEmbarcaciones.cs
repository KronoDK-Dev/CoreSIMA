using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionComercial;

namespace Controladora.GestionComercial
{
    public class cEmbarcaciones
    {
        public DataTable ListarEmbarcaciones(string V_FILTRO, string V_AMBIENTE = "T")
        {
            return (new EmbarcacionesNTAD()).ListarTodos(V_FILTRO, V_AMBIENTE);
        }
    }
}
