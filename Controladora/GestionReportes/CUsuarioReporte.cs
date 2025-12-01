using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionReportes;

namespace Controladora.GestionReportes
{
    public class CUsuarioReporte
    {
        public DataTable Buscar(string TextFind, string UserName)
        {
            return (new UsuarioReporteNTAD()).Buscar(TextFind, UserName);
        }
    }
}
