using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.SeguridadPlanta
{
    public  class personal
    {
        public personal() { }
        public string nroDoc { get; set; }
        public string participante { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string Nombres { get; set; }

        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreCurso { get; set; }
        public string fechaInicio { get; set; }
        public string fechaVencimiento { get; set; }
        public string nota1 { get; set; }
        public string nota2 { get; set; }
        public string notaProm { get; set; }
        public string estado { get; set; }
        public int aprobado { get; set; }
        public int empresaAntigua { get; set; }
        public IList<empresas> empresas { get; set; }
    }
}
