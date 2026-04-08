using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionSeguridadIndustrial
{
    public class AntecedenteAnexoBE : BaseBE
    {
        string idAnexo;
        string nombreArchivo;
        int idEstado;
        string idAntecedente;

        public string IdAnexo
        {
            get { return this.idAnexo; }
            set { this.idAnexo = value; }
        }

        public string NombreArchivo
        {
            get { return this.nombreArchivo; }
            set { this.nombreArchivo = value; }
        }

        public int IdEstado
        {
            get { return this.idEstado; }
            set { this.idEstado = value; }
        }

        public string IdAntecedente
        {
            get { return this.idAntecedente; }
            set { this.idAntecedente = value; }
        }

        public AntecedenteAnexoBE()
        {
        }
    }
}
