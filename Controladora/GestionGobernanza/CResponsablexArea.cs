using AccesoDatos.NoTransaccional.GestionGobernanza;
using AccesoDatos.Transaccional.GestionGobernanza;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionGobernanza
{
    public  class CResponsablexArea
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ResponsablexAreaNTAD()).ListarTodos(Id1, UserName);
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new ResponsablexAreaTAD()).ModificaInserta(oBaseBE);
        }
        public int Eliminar(string IdTabla,string IdItem,string UserName)
        {
            return (new ObjetivoTAD()).Eliminar(IdTabla, IdItem, UserName);
        }
    }
}
