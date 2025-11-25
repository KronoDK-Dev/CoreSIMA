using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class AtributoBE : BaseBE
    {
        private int cod_emp;
        private int rol;
        private string tipo;
        private int valor;

        public int Cod_emp
        {
            get { return cod_emp; }
            set { cod_emp = value; }
        }

        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
