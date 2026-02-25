using AccesoDatos.NoTransaccional.GestionSeguridadPlanta;
using Controladora.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SeguridadPlanta
{
    public class CVisitas
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new VisitasNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            return (new VisitasNTAD()).ListarTodos(Id1, Id2, Id3, UserName);
        }


        // Retorno de objeto dicccionario para JSON
        // DataTable tiene overhead de esquema, columnas, estados de fila, índices; está pensado para data-binding y operaciones in-memory(relaciones, constraints).
        // List<Dictionary<...>> mantiene solo los datos: para el uso típico de “consultar y serializar a JSON”, es más liviano en memoria y CPU.
        public List<Dictionary<string, object>> ListarTodos_JSON(string Id1, string Id2, string Id3, string UserName)
        {
            return (new VisitasNTAD()).ListarTodos_JSON(Id1, Id2, Id3, UserName);
        }

    }
}
