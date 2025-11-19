using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionCalidad
{
    public class InspeccionBE : BaseBE
    {
        public string IdInspeccion { get; set; }
        public string IdInspeccionPadre { get; set; }
        public string NroProyecto { get; set; }
        public string NroReporte { get; set; }

        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public int IdCLiente { get; set; }
        public string ClienteRazonSocial { get; set; }
        public DateTime FechaInspeccion { get; set; }
        public int IdTipoInspeccion { get; set; }
        public int IdTipoProceso { get; set; }
        public string NombreTipoProceso { get; set; }
        public int IdTipoSistema { get; set; }
        public int IdTipoClasificacion { get; set; }
        public string Recomendacion { get; set; }

        public string LineadeNegocio { get; set; }
        public int IdNormaClausula { get; set; }

        public int IdOrigen { get; set; }
        public int IdEntidad { get; set; }
        public string NombreAreaEntidad { get; set; }

        public InspeccionBE() { }

        public InspeccionBE(string _IdInspeccion, string _NroReporte, int _IdProyecto, string _NombreProyecto, int _IdCLiente, string _ClienteRazonSocial, DateTime _FechaInspeccion, int _IdTipoInspeccion, int _IdTipoProceso, int _IdTipoSistema, string _LineadeNegocio)
        {
            this.IdInspeccion = _IdInspeccion;
            this.NroReporte = _NroReporte;
            this.IdProyecto = _IdProyecto;
            this.NombreProyecto = _NombreProyecto;
            this.IdCLiente = _IdCLiente;
            this.ClienteRazonSocial = _ClienteRazonSocial;
            this.FechaInspeccion = _FechaInspeccion;
            this.IdTipoInspeccion = _IdTipoInspeccion;
            this.IdTipoProceso = _IdTipoProceso;
            this.IdTipoSistema = _IdTipoSistema;
            this.LineadeNegocio = _LineadeNegocio;
        }
    }
}
