using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Seguridad
{
    public class UsuarioBE : BaseBE
    {
        public int IdPersonal { get; set; }
        public string Login { get; set; }
        public string Clave { get; set; }
        public int Foto { get; set; }
        public int IdEquipo { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public string ApellidosyNombres { get; set; }
        public string Area { get; set; }
        public string CodPersonal { get; set; }
        public int IdCentroOperativo { get; set; }
        public int NroCentroOperativo { get; set; }
        public int IdContacto { get; set; }

        public UsuarioBE() { }
        public UsuarioBE(int _IdUsuario, string _Login, string _Clave, string _NroDocumento, int _IdEquipo)
        {
            this.IdUsuario = _IdUsuario;
            this.Login = _Login;
            this.Clave = _Clave;
            this.NroDocumento = _NroDocumento;
            this.IdEquipo = _IdEquipo;
        }
        public UsuarioBE(int _IdUsuario, string _Login, string _NroDocumento, int _IdEquipo, string _ApellidosyNombres)
        {
            this.IdUsuario = _IdUsuario;
            this.Login = _Login;
            this.NroDocumento = _NroDocumento;
            this.IdEquipo = _IdEquipo;
            this.ApellidosyNombres = _ApellidosyNombres;
        }
    }
}
