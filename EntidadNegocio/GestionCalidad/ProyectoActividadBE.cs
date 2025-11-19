using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class ProyectoActividadBE : BaseBE
    {
        public string IdActProy { get; set; }
        public int IdPryecto { get; set; }
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }

        public ProyectoActividadBE() { }

        public ProyectoActividadBE(string _IdActProy, int _IdPryecto, int _IdActividad, string _NombreActividad)
        {
            this.IdActProy = _IdActProy;
            this.IdPryecto = _IdPryecto;
            this.IdActividad = _IdActividad;
            this.NombreActividad = NombreActividad;
        }
    }
}
