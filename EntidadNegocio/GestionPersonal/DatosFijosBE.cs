using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.GestionPersonal
{
    public class DatosFijosBE : BaseBE
    {
        private int cod_emp;
        private int rol;
        private int ano_prc;
        private string cod_itm;
        private string dv_rol;
        private int mes_prc;
        private double mnt_itm;
        private string nivel_fun;
        private string tip_itm;
        private string mon_itm;
        private int ano_ini_vig;
        private int mes_ini_vig;
        private int ano_trm_vig;
        private int mes_trm_vig;
        private string cc;
        private string mon_alt_itm;
        private int nro_cuo;

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

        public int Ano_prc
        {
            get { return ano_prc; }
            set { ano_prc = value; }
        }

        public string Cod_itm
        {
            get { return cod_itm; }
            set { cod_itm = value; }
        }

        public string Dv_rol
        {
            get { return dv_rol; }
            set { dv_rol = value; }
        }

        public int Mes_prc
        {
            get { return mes_prc; }
            set { mes_prc = value; }
        }

        public double Mnt_itm
        {
            get { return mnt_itm; }
            set { mnt_itm = value; }
        }

        public string Nivel_fun
        {
            get { return nivel_fun; }
            set { nivel_fun = value; }
        }

        public string Tip_itm
        {
            get { return tip_itm; }
            set { tip_itm = value; }
        }

        public string Mon_itm
        {
            get { return mon_itm; }
            set { mon_itm = value; }
        }

        public int Ano_ini_vig
        {
            get { return ano_ini_vig; }
            set { ano_ini_vig = value; }
        }

        public int Mes_ini_vig
        {
            get { return mes_ini_vig; }
            set { mes_ini_vig = value; }
        }

        public int Ano_trm_vig
        {
            get { return ano_trm_vig; }
            set { ano_trm_vig = value; }
        }

        public int Mes_trm_vig
        {
            get { return mes_trm_vig; }
            set { mes_trm_vig = value; }
        }

        public string Cc
        {
            get { return cc; }
            set { cc = value; }
        }

        public string Mon_alt_itm
        {
            get { return mon_alt_itm; }
            set { mon_alt_itm = value; }
        }

        public int Nro_cuo
        {
            get { return nro_cuo; }
            set { nro_cuo = value; }
        }

    }
}
