using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;

namespace Controladora.GestionProduccion
{
    public class CValorizacion
    {
        public DataTable Listar_est_actividad(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_est_actividad(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_est_actividad_01(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_est_actividad_01(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        public DataTable Listar_lista_ots_se_01(string V_ANIO, string V_OPCION, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_lista_ots_se_01(V_ANIO, V_OPCION, UserName);
        }

        public DataTable Listar_valorizacionr(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV,
            string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionr(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
        }

        public DataTable Listar_valorizacionr_(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION,
            string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionr_(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        public DataTable Listar_valorizacionrproy(string V_CO, string V_DIVISION, string V_OT, string V_PROYECTO,
            string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionrproy(V_CO, V_DIVISION, V_OT, V_PROYECTO, UserName);
        }

        public DataTable Listar_valorizacionrproy_02(string D_FECHAFIN, string D_FECHAINI, string V_CO,
            string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionrproy_02(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION,
                V_PROYECTO, UserName);
        }

        public DataTable Listar_valorizacionrunidad(string N_CEO, string V_CODCLI, string V_CODDIV, string V_CODUND,
            string V_PERIODO, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionrunidad(N_CEO, V_CODCLI, V_CODDIV, V_CODUND, V_PERIODO,
                UserName);
        }

        public DataTable Listar_valorizacionrxan(string N_CEO, string V_CODDIV, string V_PAAMM, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionrxan(N_CEO, V_CODDIV, V_PAAMM, UserName);
        }

        public DataTable Listar_valorizacionr01(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION,
            string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionr01(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        public DataTable Listar_valorizacionrproy01(string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return (new ValorizacionNTAD()).Listar_valorizacionrproy01(V_CO, V_DIVISION, V_PROYECTO, UserName);
        }
    }
}
