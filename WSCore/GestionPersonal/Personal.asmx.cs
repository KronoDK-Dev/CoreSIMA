using Controladora.GestionPersonal;
using EntidadNegocio.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionPersonal
{
    /// <summary>
    /// Descripción breve de Personal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Personal : System.Web.Services.WebService
    {
        [WebMethod(Description = "Permite buscar a una persona")]
        public DataTable BuscarPersona(string TextFind, string UserName)
        {
            return (new CPersonal()).Buscar(TextFind, UserName);
        }

        [WebMethod(Description = "Permite buscar a una persona")]
        public DataTable BuscarPersonal(string ApellidosYnombres, string UserName)
        {
            return (new CPersonal()).Buscar(ApellidosYnombres, UserName);
        }

        [WebMethod(Description = "Permite buscar a una personal contratista")]
        public DataTable BuscarTrabajadorContratista(string TextFind, string UserName)
        {
            return (new CPersonal()).BuscarTrabajadorContratista(TextFind, UserName);
        }

        [WebMethod(Description = "Se vizualiza el detalle de personal")]
        public PersonalUbicacionBE DetallePersonaUbicacion(int IdPersonal, string UserName)
        {
            return (PersonalUbicacionBE)(new CPersonal()).Detalle(IdPersonal.ToString(), UserName);
        }

        [WebMethod(Description = "Se vizualiza el detalle de personal REGISTRADO EN O7")]
        public PersonalUbicacionBE DetallePersonaO7xCodigo(int IdPersonal, string UserName)
        {
            return (PersonalUbicacionBE)(new CPersonal()).DetalleO7(IdPersonal.ToString(), UserName);
        }

        [WebMethod(Description = "Insertar Huella ")]
        public string LeeHuallaRelogInsertaInBD(string CodTrabajador, string IdHuella, string HuellaM1, string HuellaM2, int Version, int IdOrg, int IdEstado, int IdUsuario, string UserName)
        {
            ZKFingerBE oZKFingerBE = new ZKFingerBE();

            oZKFingerBE.CodTrabajador = CodTrabajador;
            oZKFingerBE.IdHuella = IdHuella;
            oZKFingerBE.HuellaM1 = HuellaM1;
            oZKFingerBE.HuellaM2 = HuellaM2;
            oZKFingerBE.Version = Version;
            oZKFingerBE.IdOrg = IdOrg;
            oZKFingerBE.IdEstado = IdEstado;
            oZKFingerBE.IdUsuario = IdUsuario;
            
            return (new CZKFinger()).ModificaInserta(oZKFingerBE);
        }

        [WebMethod(Description = "Trasnferencia de datos fijos desde le O7 SOlution al aplicativo UNISYS ")]
        public void DatosFijosActualizar(int Ano_prc, int Cod_emp, string Cod_itm, string Dv_rol, int Mes_prc, double Mnt_itm, string Nivel_fun,
                              int Rol, string Tip_itm, string Mon_itm, int Ano_ini_vig, int Mes_ini_vig, int Ano_trm_vig, int Mes_trm_vig,
                              string Cc, string Mon_alt_itm, int Nro_cuo)
        {
            DatosFijosBE oDatosFijosBE = new DatosFijosBE();

            oDatosFijosBE.Ano_prc = Ano_prc;
            oDatosFijosBE.Cod_emp = Cod_emp;
            oDatosFijosBE.Cod_itm = Cod_itm;
            oDatosFijosBE.Dv_rol = Dv_rol;
            oDatosFijosBE.Mes_prc = Mes_prc;
            oDatosFijosBE.Mnt_itm = Mnt_itm;
            oDatosFijosBE.Nivel_fun = Nivel_fun;
            oDatosFijosBE.Rol = Rol;
            oDatosFijosBE.Tip_itm = Tip_itm;
            oDatosFijosBE.Mon_itm = Mon_itm;
            oDatosFijosBE.Ano_ini_vig = Ano_ini_vig;
            oDatosFijosBE.Mes_ini_vig = Mes_ini_vig;
            oDatosFijosBE.Ano_trm_vig = Ano_trm_vig;
            oDatosFijosBE.Mes_trm_vig = Mes_trm_vig;
            oDatosFijosBE.Cc = Cc;
            oDatosFijosBE.Mon_alt_itm = Mon_alt_itm;
            oDatosFijosBE.Nro_cuo = Nro_cuo;

            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos((new CDatosFijos()).Modificar(oDatosFijosBE).ToString());
        }

        [WebMethod(Description = "Acttualizacion de atributos en el UNISYS")]
        public void Atributos_Actualizar(int Cod_emp, int Rol, string Tipo, int Valor)
        {

            AtributoBE oAtributoBE = new AtributoBE();
            oAtributoBE.Cod_emp = Cod_emp;
            oAtributoBE.Rol = Rol;
            oAtributoBE.Tipo = Tipo;
            oAtributoBE.Valor = Valor;

            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos((new CAtributo()).Modificar(oAtributoBE).ToString());
        }

        [WebMethod(Description = "Actualizacion de vacaciones en el UNISYS")]
        public void Vacaciones_Agregar(int Rol, int Per_vac, int Mes_ter, int Mes_ini, string Dv_rol, int Dia_ter, double Dia_tdo, int Dia_ini,
          int Cod_emp, int Ano_ter, int Ano_ini)
        {
            VacacionesBE oVacacionesBE = new VacacionesBE();
            oVacacionesBE.Rol = Rol;
            oVacacionesBE.Per_vac = Per_vac;
            oVacacionesBE.Mes_ter = Mes_ter;
            oVacacionesBE.Mes_ini = Mes_ini;
            oVacacionesBE.Dv_rol = Dv_rol;
            oVacacionesBE.Dia_ter = Dia_ter;
            oVacacionesBE.Dia_tdo = Dia_tdo;
            oVacacionesBE.Dia_ini = Dia_ini;
            oVacacionesBE.Cod_emp = Cod_emp;
            oVacacionesBE.Ano_ter = Ano_ter;
            oVacacionesBE.Ano_ini = Ano_ini;

            string IdResult = (new CVacaciones()).Insertar(oVacacionesBE).ToString();
            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(IdResult);
        }

        [WebMethod(Description = "Eliminar de vacaciones en el UNISYS")]
        public void Vacaciones_Eliminar(int Rol, int Per_vac, int Mes_ter, int Mes_ini, string Dv_rol, int Dia_ter, double Dia_tdo, int Dia_ini, int Cod_emp, int Ano_ter, int Ano_ini)
        {
            VacacionesBE oVacacionesBE = new VacacionesBE();
            oVacacionesBE.Rol = Rol;
            oVacacionesBE.Per_vac = Per_vac;
            oVacacionesBE.Mes_ter = Mes_ter;
            oVacacionesBE.Mes_ini = Mes_ini;
            oVacacionesBE.Dv_rol = Dv_rol;
            oVacacionesBE.Dia_ter = Dia_ter;
            oVacacionesBE.Dia_tdo = Dia_tdo;
            oVacacionesBE.Dia_ini = Dia_ini;
            oVacacionesBE.Cod_emp = Cod_emp;
            oVacacionesBE.Ano_ter = Ano_ter;
            oVacacionesBE.Ano_ini = Ano_ini;

            string IdResult = (new CVacaciones()).Eliminar(oVacacionesBE).ToString();
            Utilitario.Helper.Archivo.XMLinURL.TransaccionalAccesoDatos(IdResult);
        }
    }
}
