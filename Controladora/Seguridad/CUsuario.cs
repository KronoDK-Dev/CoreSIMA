using AccesoDatos.NoTransaccional.Seguridad;
using Controladora.HelpDesk.ChatBot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Transaccional.Seguridad;
using EntidadNegocio.Seguridad;

namespace Controladora.Seguridad
{
    public class CUsuario
    {
        public DataTable GetPerfiles(int IdUser, string UserName)
        {
            return (new UsuarioNTAD()).GetUserInfo(IdUser, UserName);
        }

        public int ValidateUser(string login, string password)
        {
            return (new UsuarioNTAD()).ValidateUser(login, password);
        }

        public int ValidateUser(string login, string password, string LADP)
        {
            return (new UsuarioNTAD()).ValidateUserAD(login, password, LADP);
        }

        public bool VerificaCaducidadUser(int IdUsuario)
        {
            return (new UsuarioNTAD()).VerificaCaducidadUser(IdUsuario);
        }

        public DataTable GetOptionsByProfile(int idSystem, int idProfile, string pagina)
        {
            return (new UsuarioNTAD()).GetOptionsByProfile(idSystem, idProfile, pagina);
        }

        public DataTable GetPerfilAccesoDirecto(int idSystem, int idUsuario)
        {
            return (new UsuarioNTAD()).GetPerfilAccesoDirecto(idSystem, idUsuario);
        }
        /*  12/02/2026 cambiado por que si se cae el metodo en oracle no deja terminar la ejecucipn del metodo
        public UsuarioBE GetDatosUsuario(int idUsuario)
        {
            UsuarioBE oUBE = (new UsuarioNTAD()).GetDatosUsuario(idUsuario);
            DataTable dt = (new CCBContactoGrupo()).DetalleContacto(oUBE.CodPersonal, "");
            if (dt.Rows.Count > 0)
            {
                oUBE.IdContacto = Convert.ToInt32(dt.Rows[0]["ID_CONTACT"].ToString());
            }
            return oUBE;
        }
        */
        public UsuarioBE GetDatosUsuario(int idUsuario)
        {
            // 1) Datos base del usuario (si esto falla, sí es crítico)
            var oUBE = (new UsuarioNTAD()).GetDatosUsuario(idUsuario);
            if (oUBE == null) return null;

            // 2) Enriquecimiento NO crítico: si falla, log y continuamos
            try
            {
                if (!string.IsNullOrWhiteSpace(oUBE.CodPersonal))
                {
                    // Si puedes, asegúrate de que DetalleContacto use CommandTimeout interno
                    var dt = (new CCBContactoGrupo()).DetalleContacto(oUBE.CodPersonal, string.Empty);
                    if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("ID_CONTACT"))
                    {
                        if (int.TryParse(dt.Rows[0]["ID_CONTACT"]?.ToString(), out var idc))
                            oUBE.IdContacto = idc;
                    }
                }
            }
            catch (Exception ex) // puedes filtrar a SqlException/InvalidOperationException si quieres
            {
                // Loguea y sigue. No relanzas.
                System.Diagnostics.Trace.TraceError(
                    $"[GetDatosUsuario] Falló DetalleContacto (CodPersonal='{oUBE.CodPersonal}'). Error: {ex}");
                // oUBE.IdContacto queda con su valor por defecto (0 o null, según el tipo)
            }

            return oUBE;
        }

        public DataTable CodigoUsuario(string s_idUsuario)
        {
            return (new UsuarioNTAD()).CodigoUsuario(s_idUsuario);
        }

        public int AsignarSucursal(int i_IdUsuario, int i_IdCentro, string s_UserName)
        {
            return (new UsuarioTAD()).AsignarSucursal(i_IdUsuario, i_IdCentro, s_UserName);
        }

        public string AsignarLineaUsuario(string sUserId, string sUnidado_clase, string slinea, string sSublinea, string UserName)
        {
            return (new UsuarioTAD()).AsignarLineaUsuario(sUserId, sUnidado_clase, slinea, sSublinea, UserName);
        }
    }
}
