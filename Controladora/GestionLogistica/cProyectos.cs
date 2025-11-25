using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cProyectos
    {
        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            return (new ProyectosNTAD()).Listar_PRY_PAG_TOT(Centro_Operativo, división, Proyecto, Nro_Orden, Procedencia,
                Tipo_Orden, UserName);
        }
    }
}
