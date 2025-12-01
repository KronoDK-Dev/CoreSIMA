using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.HelpDesk
{
    public class AprobadorBE : BaseBE
    {
        public AprobadorBE() { }
        public string IdResponsable { get; set; }
        public string IdRequerimiento { get; set; }
        public string IdPersonal { get; set; }
        public AprobadorBE(string idRequerimiento, string idResponsable, string idPersonal, int idUsuario, string userName)
        {
            this.IdRequerimiento = idRequerimiento;
            this.IdResponsable = idResponsable;
            this.IdPersonal = idPersonal;
            this.IdUsuario = idUsuario;
            this.UserName = userName;

        }
    }
}
