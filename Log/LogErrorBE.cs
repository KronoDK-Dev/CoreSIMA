using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace Log
{
    public class LogErrorBE : LogBE
    {
        public string exceptionName { get; set; }

        private LogErrorBE()
        {
        }

        public override string ToString()
        {
            string str1 = $"{DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd)} {DateTime.Now.ToString(Constante.Formato.Hora.Estandar)} {DateTime.Now.ToString(Constante.Formato.Fecha.AÑO)}";
            string str2 = $"{$"{$"{$"{"===> " + "Versión [01.00.00] "}Usuario [{this.usuario}] "}Módulo [{this.modulo}] "}TipoExcep [{this.exceptionName}] "}Descripción [{this.descripcion}] ";
            string newLine = Environment.NewLine;
            string str3 = str2;
            return str1 + newLine + str3;
        }

        public LogErrorBE(string Usuario, string Modulo, string ExceptionName, string Descripcion)
        {
            this.usuario = Usuario;
            this.modulo = Modulo;
            this.descripcion = Descripcion;
            this.exceptionName = ExceptionName;
        }
    }

}
