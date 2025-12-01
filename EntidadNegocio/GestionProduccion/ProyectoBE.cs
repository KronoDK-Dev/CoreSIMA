using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionProduccion
{
    public class ProyectoBE : BaseBE
    {
        public int IdProyecto { get; set; }
        public string CodigoProy { get; set; }
        public string Nombre { get; set; }
        public int IdCliente { get; set; }
        public string ClienteRazonSocial { get; set; }
        public int IdLN { get; set; }

        public ProyectoBE()
        {

        }

        public ProyectoBE(int _IdProyecto, string _CodigoProy, string _Nombre, int _IdCliente, int _IdLN)
        {
            this.IdProyecto = _IdProyecto;
            this.CodigoProy = _CodigoProy;
            this.Nombre = _Nombre;
            this.IdCliente = _IdCliente;
            this.IdLN = _IdLN;
        }
    }
}
