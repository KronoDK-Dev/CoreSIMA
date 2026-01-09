using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class Constante
    {
        public struct Caracteres
        {
            public static readonly string Espacio = " ";
            public static readonly string SeperadorSimple = "¦ ";
            public static readonly string SeperadorDoble = SeperadorSimple + SeperadorSimple;
            public static readonly string Punto = ".";
            public static readonly string DosPunto = ":";

            public static readonly string Coma = ",";
            public static readonly string Igual = "=";
            public static readonly int ValorConstanteCero = 0; //Numero Cero

            public static readonly string LineaSimple = "_";
            public static readonly string PuntoyComa = ";";
            public static readonly string Mas = "+";
            public static readonly string Amperson = "&";
            public static readonly string interrogacion = "?";
            public static readonly string Porcentaje = "%";
            public static readonly string Diferentede = "<>";
            public static readonly string MayoroIgual = ">=";
            public static readonly string MenoroIgula = "<=";
            public static readonly string X = "X";
            public static readonly string Diagonal = "/";
            public static readonly string Linea = "-";
            public static readonly string SeparadorLinea = " - ";
            public static readonly string Vacio = "";
            public static readonly string Arroba = "@";
            public static readonly string Meno = "<";
            public static readonly string Mayor = ">";
            public static readonly string ParentesisOpen = "(";
            public static readonly string ParentesisClose = ")";
            public static readonly string CorchetesOpen = "[";
            public static readonly string CorchetesClose = "]";
            public static readonly string ComillasDobles = "\"";
            public static readonly string ComillasSimples = "'";
            public static readonly string LineaVertical = "|";
            public static readonly string EspacioEnBlancoHTML = "&nbsp;"; //Un Espacio en Blanco para HTML.
            public static readonly string EspacioEnBlancoVS = " "; // Un Espacio en Blanco para Visual Studio.
            public static readonly string SaltoDeLinea = "\n";
            public static readonly string SaltoLineaHTML = "<br>";
            public static readonly string Asterisco = "*";



        }

        public struct Archivo
        {
            public struct Extension
            {
                public static string TXT = Constante.Caracteres.Punto + "txt";
                public static string XLS = Constante.Caracteres.Punto + "xls";
                public static string DOC = Constante.Caracteres.Punto + "doc";
            }

            public struct Prefijo
            {
                public static readonly string LOGAPLICATIVOERROR = "APLERR";
                public static readonly string LOGAPLICATIVO = "APL";
                public static readonly string LOGTRANSACCIONAL = "LOG";
                public static readonly string CODIGOERRORLOG = "LOG";
                static public readonly string PREFIJOCODIGOERRORNTAD = "NTA";
                static public readonly string PREFIJOCODIGOERRORWS = "WS";
            }
        }

        public struct LogCtrl
        {
            public static readonly string CODIGOERRORGENERICOTAD = "TAD00000";
            public static readonly string CODIGOERRORGENERICONTAD = "NTA00000";
            public static readonly string CEROS = "000000000";
        }

        public struct Formato
        {
            public struct Fecha
            {
                public static string YYYYMM = "yyyyMM";
                public static string ddMMyyyyhhmmss = "dd / MM/yyyy hh:mm:ss";

                public static readonly string ddddMMMdd = "dddd MMM dd";//FORMATOFECHA
                public static readonly string yyyyMMdd = "yyyyMMdd";//FORMATOFECHA2
                public static readonly string SddMMyyyy = "dd/MM/yyyy";//FORMATOFECHA3
                public static readonly string GddMMyyyy = "dd-MM-yyyy";//FORMATOFECHA4
                public static readonly string GyyyyMMdd = "yyyy-MM-dd";//FORMATOFECHA5 
                public static readonly string AÑO = "yyyy";
            }
            public struct Hora
            {
                public static readonly string Estandar = "HH:mm:ss";
                public static string HHmmssf = "hh:mm:ss.f";// Displays 07:27:15.0
                public static string HHmmssF = "hh:mm:ss.F";// Displays 07:27:15
                public static string HHmmssff = "hh:mm:ss.ff";// Displays 07:27:15.01
                public static string HHmmssFF = "hh:mm:ss.FF";// Displays 07:27:15.01
                public static string HHmmssfff = "hh:mm:ss.fff";// Displays 07:27:15.018
                public static string HHmmssFFF = "hh:mm:ss.FFF";// Displays 07:27:15.018
            }

        }


    }
}
