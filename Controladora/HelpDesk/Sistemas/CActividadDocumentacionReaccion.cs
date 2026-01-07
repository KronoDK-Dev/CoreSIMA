using AccesoDatos.NoTransaccional.HelpDesk.Sistemas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.Sistemas
{
    public  class CActividadDocumentacionReaccion
    {
        public DataTable ListarTodos(string Id1, string UserName)
        { 
            return (new ActividadDocumentacionReaccionNTAD()).ListarTodos(Id1, UserName);   
        }
    }
}
