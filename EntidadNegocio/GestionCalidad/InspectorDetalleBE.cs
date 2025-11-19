using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class InspectorDetalleBE : BaseBE
    {
        public string IdDetalleInspeccion { get; set; }
        public string IdInspector { get; set; }
        public DateTime Fecha { get; set; }
        public string Recomendaciones { get; set; }
        public int IdClausula { get; set; }

        public InspectorDetalleBE() { }

        public InspectorDetalleBE(string _IdDetalleInspeccion, string _IdInspector, DateTime _Fecha, string _Descripcion, string _Recomendaciones, int _IdClausula, int _IdUsuario)
        {
            this.IdDetalleInspeccion = _IdDetalleInspeccion;
            this.IdInspector = _IdInspector;
            this.Fecha = _Fecha;
            this.Descripcion = _Descripcion;
            this.Recomendaciones = _Recomendaciones;
            this.IdClausula = _IdClausula;
            this.IdUsuario = _IdUsuario;
        }
    }
}
