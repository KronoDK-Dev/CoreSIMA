using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cServicios
    {
        public DataTable Listar_Catalogo_Servicios_SR(string CLASE, string UserName)
        {
            return (new ServiciosNTAD()).Listar_Catalogo_Servicios_SR(CLASE, UserName);
        }

        public DataTable Listar_DET_G_PRY_OT_SER_PCI(string Centro_Operativo, string Division, string Proyecto, string UserName)
        {
            return (new ServiciosNTAD()).Listar_DET_G_PRY_OT_SER_PCI(Centro_Operativo, Division, Proyecto, UserName);
        }

        public DataTable Listar_OS_DETALLE_OTS(string s_fecha_ini, string s_fecha_fin, string UserName)
        {
            return (new ServiciosNTAD()).Listar_OS_DETALLE_OTS(s_fecha_ini, s_fecha_fin, UserName);
        }
    }
}
