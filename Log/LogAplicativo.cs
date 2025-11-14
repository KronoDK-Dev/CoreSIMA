using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilitario;

namespace Log
{
    public class LogAplicativo : LogBE
    {
        private string ipCliente;
        private string paginaCliente;

        public LogAplicativo()
        {
        }

        public LogAplicativo(
            string usuario,
            string modulo,
            string paginaCliente,
            string descripcion,
            string nivelLog)
        {
            this.usuario = usuario;
            this.modulo = modulo;
            this.paginaCliente = paginaCliente;
            this.descripcion = descripcion;
            this.ipCliente = HttpContext.Current.Request.UserHostAddress;
            this.nivel = nivelLog;
        }

        public override string ToString()
        {
            string str1 = $"{DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd)} {DateTime.Now.ToString(Constante.Formato.Hora.Estandar)} {DateTime.Now.ToString(Constante.Formato.Fecha.AÑO)}: [{this.nivel.Trim()}]";
            string str2 = $"{$"{$"{$"{$"{"===> " + "Versión [01.00.00] "}IP Cliente [{this.ipCliente}] "}Usuario [{this.usuario}] "}Módulo [{this.modulo}] "}Página [{this.paginaCliente}] "}Descripción [{this.descripcion}] ";
            string newLine = Environment.NewLine;
            string str3 = str2;
            return str1 + newLine + str3;
        }

        public static void GrabarLogAplicativoArchivo(LogAplicativo Log)
        {
            ManejoLog.GrabarLog((object)Log, Enumerados.TipoLog.A.ToString());
        }
    }
}
