using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;

namespace Controladora.General
{
    public class CEmpresa
    {
        public DataTable ObtenerCredencialEMP(string IdEmp)
        {
            return (new EmpresaNTAD()).ObtenerCredencialEMP(IdEmp);
        }
    }
}
