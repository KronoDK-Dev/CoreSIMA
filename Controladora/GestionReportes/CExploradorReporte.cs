using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CExploradorReporte
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarTodos(Id1, UserName);
        }

        public DataTable ListarTodosCompartidos(int IdUsuario, int IdObjetoPadre, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarTodosCompartidos(IdUsuario, IdObjetoPadre, UserName);
        }

        public DataTable ListarTodosPorUsuario(string Id1, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarTodosPorUsuario(Id1, UserName);
        }

        public DataTable ListarTodosDependientes(string Id1, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarTodosDependientes(Id1, UserName);
        }

        public DataTable ListarInfoReport(string IdReport, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarInfoReport(IdReport, UserName);
        }

        public DataTable ListarHeader(string Id1, string UserName)
        {
            return (new ExploradorReporteNTAD()).ListarHeader(Id1, UserName);
        }
    }
}
