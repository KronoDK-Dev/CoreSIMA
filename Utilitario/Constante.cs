using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class Constante
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Caracteres
        {
            public static readonly string Espacio = " ";
            public static readonly string SeperadorSimple = "¦ ";
            public static readonly string SeperadorDoble = Constante.Caracteres.SeperadorSimple + Constante.Caracteres.SeperadorSimple;
            public static readonly string Punto = ".";
            public static readonly string DosPunto = ":";
            public static readonly string Coma = ",";
            public static readonly string Igual = "=";
            public static readonly int ValorConstanteCero = 0;
            public static readonly string LineaSimple = "_";
            public static readonly string PuntoyComa = ";";
            public static readonly string Mas = "+";
            public static readonly string Amperson = "&";
            public static readonly string interrogacion = "?";
            public static readonly string Porcentaje = "%";
            public static readonly string Diferentede = "<>";
            public static readonly string MayoroIgual = ">=";
            public static readonly string MenoroIgula = "<=";
            public static readonly string X = nameof(X);
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
            public static readonly string EspacioEnBlancoHTML = "&nbsp;";
            public static readonly string EspacioEnBlancoVS = " ";
            public static readonly string SaltoDeLinea = "\n";
            public static readonly string SaltoLineaHTML = "<br>";
            public static readonly string Asterisco = "*";
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Archivo
        {
            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Extension
            {
                public static string TXT = Constante.Caracteres.Punto + "txt";
                public static string XLS = Constante.Caracteres.Punto + "xls";
                public static string DOC = Constante.Caracteres.Punto + "doc";
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Prefijo
            {
                public static readonly string LOGAPLICATIVOERROR = "APLERR";
                public static readonly string LOGAPLICATIVO = "APL";
                public static readonly string LOGTRANSACCIONAL = "LOG";
                public static readonly string CODIGOERRORLOG = "LOG";
                public static readonly string PREFIJOCODIGOERRORNTAD = "NTA";
                public static readonly string PREFIJOCODIGOERRORWS = "WS";
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct LogCtrl
        {
            public static readonly string CODIGOERRORGENERICOTAD = "TAD00000";
            public static readonly string CODIGOERRORGENERICONTAD = "NTA00000";
            public static readonly string CEROS = "000000000";
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Formato
        {
            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Fecha
            {
                public static string YYYYMM = "yyyyMM";
                public static string ddMMyyyyhhmmss = "dd / MM/yyyy hh:mm:ss";
                public static readonly string ddddMMMdd = "dddd MMM dd";
                public static readonly string yyyyMMdd = nameof(yyyyMMdd);
                public static readonly string SddMMyyyy = "dd/MM/yyyy";
                public static readonly string GddMMyyyy = "dd-MM-yyyy";
                public static readonly string GyyyyMMdd = "yyyy-MM-dd";
                public static readonly string AÑO = "yyyy";
            }

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct Hora
            {
                public static readonly string Estandar = "HH:mm:ss";
                public static string HHmmssf = "hh:mm:ss.f";
                public static string HHmmssF = "hh:mm:ss.F";
                public static string HHmmssff = "hh:mm:ss.ff";
                public static string HHmmssFF = "hh:mm:ss.FF";
                public static string HHmmssfff = "hh:mm:ss.fff";
                public static string HHmmssFFF = "hh:mm:ss.FFF";
            }
        }
    }
}
