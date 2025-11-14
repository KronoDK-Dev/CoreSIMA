using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public abstract class LogBE
    {
        protected string usuario;
        protected string modulo;
        protected string descripcion;
        protected string nivel;
        private const string SeccionConfig = "LogSeccion";
        private const string LogFile = "RutaFileLog";

        public static string RutaLog
        {
            get
            {
                return ((Hashtable)ConfigurationManager.GetSection("LogSeccion"))[(object)"RutaFileLog"].ToString();
            }
        }
    }
}
