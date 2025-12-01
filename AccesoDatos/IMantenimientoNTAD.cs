using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface IMantenimientoNTAD
    {
        DataTable ListarTodos();
        DataTable ListarTodos(string Id1, string UserName);
        DataTable ListarTodos(string Id1, string Id2, string UserName);
        DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName);

        DataTable Buscar(string TextFind, string UserName);

        BaseBE Detalle(string Id1);
        BaseBE Detalle(string Id1, string UserName);
        BaseBE Detalle(string Id1, string Id2, string UserName);
        BaseBE Detalle(string Id1, string Id2, string Id3, string UserName);
    }
}
