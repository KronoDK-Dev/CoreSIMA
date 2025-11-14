using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorException
{
    public class ManejoExcepcion
    {
        private static string obtenerMensajeUsuario(string codigoError)
        {
            string seccionConfig = ManejoExcepcion.Configuracion.Seccion.get(ManejoExcepcion.Configuracion.Seccion.Nombre.MensajesError.ToString(), codigoError);
            if (seccionConfig == "")
                seccionConfig = ManejoExcepcion.getSeccionConfig(ManejoExcepcion.Configuracion.Seccion.Nombre.MensajesError.ToString(), "00000");
            return seccionConfig;
        }

        public static SIMAExcepcion CrearSIMAExcepcion(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcion(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        public static SIMAExcepcionLog CrearSIMAExcepcionLog(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcionLog(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        public static SIMAExcepcionIU CrearSIMAExcepcionIU(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcionIU(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        public static SIMAExcepcionDominio CrearSIMAExcepcionDominio(
          string codigoError,
          string errorTecnico)
        {
            return new SIMAExcepcionDominio(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        private static string getSeccionConfig(string Seccion, string Llave)
        {
            string seccionConfig = "";
            try
            {
                Hashtable section = (Hashtable)ConfigurationManager.GetSection(Seccion);
                if (section != null)
                    seccionConfig = Convert.ToString(section[(object)Llave]);
                return seccionConfig;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return "";
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Configuracion
        {
            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Seccion
            {
                public const string CodigoGenerico = "00000";

                public static string get(string Seccion, string Llave)
                {
                    string str = "";
                    try
                    {
                        Hashtable section = (Hashtable)ConfigurationManager.GetSection(Seccion);
                        if (section != null)
                            str = Convert.ToString(section[(object)Llave]);
                        return str;
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        return "";
                    }
                }

                public enum Nombre
                {
                    MensajesError,
                }
            }
        }
    }
}
