using AccesoDatos.NoTransaccional.General;
using AccesoDatos.NoTransaccional.GestionComercial;
using AccesoDatos.Transaccional.GestionComercial;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionComercial
{
    public class cSolicitud
    {
        public DataTable DetalleSolicitud(string V_AMBIENTE, string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new SolicitudNTAD()).DetalleSolicitud(V_AMBIENTE, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        public DataTable DetalleSolicitud2(string V_AMBIENTE, string V_CEO, string V_ID_SOLICITUD, string V_COD_DIV, string UserName)
        {
            return (new SolicitudNTAD()).DetalleSolicitud2(V_AMBIENTE, V_CEO, V_ID_SOLICITUD, V_COD_DIV, UserName);
        }

        public DataTable ListarSolicitudTrabajo(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI,
            string V_FEC_STR_FIN, string UserName)
        {
            return (new SolicitudNTAD()).ListarSolicitudTrabajo(V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
        }
        public DataTable ListarSolicitudTrabajo_SQL(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            return (new SolicitudNTAD()).ListarSolicitudTrabajo_SQL(V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
        }

        public List<Dictionary<string, object>> ListarSolicitudTrabajo_JSON(string V_AMBIENTE, string V_FILTRO, string V_CEO, string V_UND_OPER, string V_FEC_STR_INI, string V_FEC_STR_FIN, string UserName)
        {
            return (new SolicitudNTAD()).ListarSolicitudTrabajo_JSON(V_AMBIENTE, V_FILTRO, V_CEO, V_UND_OPER, V_FEC_STR_INI, V_FEC_STR_FIN, UserName);
        }

        public string InsertarSolicitud(BaseBE oBaseBE, string v_ambiente = "T")
        {
            return (new          SolicitudTAD()).InsertarSolicitud(oBaseBE, v_ambiente);
        }

        public DataTable Lista_Lineas_Usuario(string s_USUARIO, string UserName)
        {
            return (new SolicitudNTAD()).Lista_Lineas_Usuario(s_USUARIO, UserName);
        }
    }
}
