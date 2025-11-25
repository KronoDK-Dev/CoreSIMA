using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class VacacionesBE : BaseBE
    {
        private int rol;
        private int per_vac;
        private int mes_ter;
        private int mes_ini;
        private string dv_rol;
        private int dia_ter;
        private double dia_tdo;
        private int dia_ini;
        private int cod_emp;
        private int ano_ter;
        private int ano_ini;

        public int Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public int Per_vac
        {
            get { return per_vac; }
            set { per_vac = value; }
        }

        public int Mes_ter
        {
            get { return mes_ter; }
            set { mes_ter = value; }
        }

        public int Mes_ini
        {
            get { return mes_ini; }
            set { mes_ini = value; }
        }

        public string Dv_rol
        {
            get { return dv_rol; }
            set { dv_rol = value; }
        }

        public int Dia_ter
        {
            get { return dia_ter; }
            set { dia_ter = value; }
        }

        public double Dia_tdo
        {
            get { return dia_tdo; }
            set { dia_tdo = value; }
        }
        public int Dia_ini
        {
            get { return dia_ini; }
            set { dia_ini = value; }
        }

        public int Cod_emp
        {
            get { return cod_emp; }
            set { cod_emp = value; }
        }

        public int Ano_ter
        {
            get { return ano_ter; }
            set { ano_ter = value; }
        }

        public int Ano_ini
        {
            get { return ano_ini; }
            set { ano_ini = value; }
        }
    }
}
