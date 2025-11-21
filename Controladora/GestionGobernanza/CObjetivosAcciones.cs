using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionGobernanza;

namespace Controladora.GestionGobernanza
{
    public class CObjetivosAcciones
    {
        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            return (new ObjetivosAccionesNTAD()).ListarTodos(Id1, Id2, UserName);
        }
    }
}
