using Controladora.GestionCalidad;
using Log;
using ManejadorException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controladora.Seguridad;
using EntidadNegocio.Seguridad;
using Utilitario;

namespace WSCore.Seguridad
{
    /// <summary>
    /// Descripción breve de Seguridad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Seguridad : System.Web.Services.WebService
    {
        public string MODULO = "";
        public string PATHWS = "";

        [WebMethod(Description = "Listar Perfiles por usuario")]
        public DataTable GetPerfiles(int IdUser, string UserName)
        {
            PATHWS = this.GetType().FullName + ".asmx";
            MODULO = PATHWS;// this.GetType().Name + ".asmx";

            try
            {
                return (new CUsuario()).GetPerfiles(IdUser, UserName);
            }
            catch (SIMAExcepcionLog oSIMAExcepcionLog)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "SIMAExcepcionLog", oSIMAExcepcionLog.Message));

                return null;

            }
            catch (SIMAExcepcionIU oSIMAExcepcionIU)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "SIMAExcepcionIU", oSIMAExcepcionIU.Message));

                return null;

            }
            catch (SIMAExcepcionDominio oSIMAExcepcionDominio)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "SIMAExcepcionDominio", oSIMAExcepcionDominio.Message));
                return null;
            }
            catch (Exception oException)
            {
                LogTransaccional.GrabarLogErrorArchivo(new LogErrorBE(UserName, MODULO, "Exception", oException.Message));
                return null;
            }
        }

        [WebMethod(Description = "Valida usuario")]
        public int ValidateUser(string login, string password)
        {
            return (new CUsuario()).ValidateUser(login, password);
        }

        [WebMethod(Description = "Valida usuario en Active Directory")]
        public int ValidateUserAD(string login, string password)
        {
            return (new CUsuario()).ValidateUser(login, password, Helper.Configuracion.Autenticacion.getLDAP);
        }

        [WebMethod(Description = "Verifica caducidad del usuario")]
        public bool VerificaCaducidadUser(int IdUsuario)
        {
            return (new CUsuario()).VerificaCaducidadUser(IdUsuario);
        }

        [WebMethod(Description = "Lista Opciones por perfil de usuario")]
        public DataTable GetOptionsByProfile(int idSystem, int idProfile, string pagina)
        {
            return (new CUsuario()).GetOptionsByProfile(idSystem, idProfile, pagina);
        }

        [WebMethod(Description = "Lista Acceso Directo de Opciones por usuario")]
        public DataTable GetPerfilAccesoDirecto(int idSystem, int idUsuario)
        {
            return (new CUsuario()).GetPerfilAccesoDirecto(idSystem, idUsuario);
        }

        [WebMethod(Description = "Datos del Usuario por codigo de usuario SIMANET")]
        public UsuarioBE GetDatosUsuario(int idUsuario)
        {
            return (new CUsuario()).GetDatosUsuario(idUsuario);
        }

        [WebMethod(Description = "Codigo de Usuario Simanet por codigo de usuario de Red")]
        public DataTable CodigoUsuario(string s_idUsuario)
        {
            return (new CUsuario()).CodigoUsuario(s_idUsuario);
        }

        [WebMethod(Description = "Asignar Sucursal a Usuario, por idusuario  y idcentro  (valores de SIMANET)")]
        public int AsignarSucursal(int i_IdUsuario, int i_IdCentro, string s_UserName)
        {
            return (new CUsuario()).AsignarSucursal(i_IdUsuario, i_IdCentro, s_UserName);
        }

        [WebMethod(Description = "Asignar Linea de Negocio a Usuario")]
        public string AsignarLineaUsuario(string LoginNetsuite, string sUnidado_clase, string slinea, string sSublinea, string UserName)
        {
            return (new CUsuario()).AsignarLineaUsuario(LoginNetsuite, sUnidado_clase, slinea, sSublinea, UserName);
        }

        [WebMethod(Description = "Cambiar estado de Inspeccion")]
        public int InspeccionCambiarEstado(string IdInspeccion, int IdEstado, int IdUsuario, string UserName)
        {
            return (new Cinspecciones()).CambiarEstado(IdInspeccion, IdEstado, IdUsuario, UserName);
        }
    }
}
