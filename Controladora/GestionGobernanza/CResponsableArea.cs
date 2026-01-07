using AccesoDatos.NoTransaccional.GestionGobernanza;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionGobernanza
{
    public  class CResponsableArea
    {
        public DataTable ListarTodos(string CodEmp, string CodCeo, string CodArea, string UserName) {
            return (new ResponsableAreaNTAD()).ListarTodos(CodEmp, CodCeo,CodArea, UserName);
        }
    }
}
