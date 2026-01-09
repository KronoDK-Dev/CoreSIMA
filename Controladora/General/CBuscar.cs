using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;

namespace Controladora.General
{
    public class CBuscar
    {
        public DataTable BuscarPersonal(string TextFind, string UserName)
         {
             return (new BuscarNTAD()).BuscarPersonal(TextFind, UserName);
         }
         public DataTable BuscarPersonal( string TextFind, string CodArea, string UserName)
         {
             return (new BuscarNTAD()).BuscarPersonal( TextFind, CodArea, UserName);
         }
         public DataTable BuscarArea(string TextFind, string UserName)
         {
             return (new BuscarNTAD()).BuscarArea(TextFind, UserName);
         }
         public DataTable BuscarArea(string CodEmpresa,string CodCentro,string TextFind, string UserName)
         {
             return (new BuscarNTAD()).BuscarArea(CodEmpresa, CodCentro, TextFind, UserName);
         }
    }
}
