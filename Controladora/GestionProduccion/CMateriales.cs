using Controladora.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CMateriales
    {
        public DataTable Listar_Lista_Materiales(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new MaterialesNTAD()).Listar_lista_materiales(V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_materiales_test(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new MaterialesNTAD()).Listar_materiales_test(V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_Saldo_Valorizado_Material(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            return (new MaterialesNTAD()).Listar_Saldo_Valorizado_Material(N_CEO, V_ANIO, V_MES, UserName);
        }

        public DataTable Listar_ComparVentvsCostoProyecotR(string V_Centro_Operativo, string V_Division,
            string V_Periodo, string V_Proyecto, string UserName)
        {
            return (new MaterialesNTAD()).Listar_ComparVentvsCostoProyecotR(V_Centro_Operativo, V_Division, V_Periodo, V_Proyecto,
                UserName);
        }

        public DataTable Listar_ComparVentvsCostoProyec_ot(string V_Centro_Operativo, string V_Division,
            string V_Periodo, string V_Proyecto, string UserName)
        {
            return (new MaterialesNTAD()).Listar_ComparVentvsCostoProyec_ot(V_Centro_Operativo, V_Division, V_Periodo, V_Proyecto,
                UserName);
        }

        public DataTable Listar_OTS_por_Proyecto(string V_Centro_Operativo, string V_Division, string V_Proyecto,
            string UserName)
        {
            return (new MaterialesNTAD()).Listar_OTS_por_Proyecto(V_Centro_Operativo, V_Division, V_Proyecto, UserName);
        }
    }
}
