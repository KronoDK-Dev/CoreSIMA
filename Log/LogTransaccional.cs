using ManejadorException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace Log
{
    public class LogTransaccional : LogBE
    {
        private string resultado;
        private string detalle;
        private string procedimientoAlmacenado;
        private string parametros;

        public LogTransaccional()
        {
        }

        public LogTransaccional(
          string Usuario,
          string Modulo,
          string Descripcion,
          string ProcedimientoAlmacenado,
          string Parametros,
          string Resultado,
          string Detalle,
          string NivelLog)
        {
            this.usuario = Usuario;
            this.modulo = Modulo;
            this.descripcion = Descripcion;
            this.procedimientoAlmacenado = ProcedimientoAlmacenado;
            this.parametros = Parametros;
            this.resultado = Resultado;
            this.detalle = Detalle;
            this.nivel = NivelLog;
        }

        public override string ToString()
        {
            string str1 = $"{DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd)} {DateTime.Now.ToString(Constante.Formato.Hora.Estandar)} {DateTime.Now.ToString(Constante.Formato.Fecha.AÑO)}: [{this.nivel.Trim()}]";
            string str2 = $"{$"{$"{$"{$"{$"{$"{"===> " + "Versión [01.00.00] "}Usuario [{this.usuario}] "}Módulo [{this.modulo}] "}Descripción [{this.descripcion}] "}Procedimiento Almacenado [{this.procedimientoAlmacenado}] "}Parametros [{this.parametros}] "}Resultado [{this.resultado.ToString().Trim()}] "}Detalle [{this.detalle}] ";
            string newLine = Environment.NewLine;
            string str3 = str2;
            return str1 + newLine + str3;
        }

        public static void LanzarSIMAExcepcionDominio(
          string user,
          string modulo,
          string origen,
          string codError,
          string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, $"Error - Origen: [{origen}]", "", "", codError, excepcion, Convert.ToString((object)Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionDominio(codError, excepcion);
        }

        public static SIMAExcepcionIU LanzarSIMAExcepcionIU(
          string user,
          string modulo,
          string origen,
          string codError,
          string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, $"Error - Origen: [{origen}]", "", "", codError, excepcion, Convert.ToString((object)Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionIU(codError, excepcion);
        }

        public static SIMAExcepcionIU CrearSIMAExcepcionIU(
          string user,
          string modulo,
          string origen,
          string codError,
          string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, $"Error - Origen: [{origen}]", "", "", codError, excepcion, Convert.ToString((object)Enumerados.NivelesErrorLog.E)));
            return ManejoExcepcion.CrearSIMAExcepcionIU(codError, excepcion);
        }

        public static void LanzarSIMAExcepcionLog(
          string user,
          string modulo,
          string origen,
          string codError,
          string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, $"Error - Origen: [{origen}]", "", "", codError, excepcion, Convert.ToString((object)Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionLog(codError, excepcion);
        }

        public static void GrabarLogTransaccionalArchivo(LogTransaccional Log)
        {
            ManejoLog.GrabarLog((object)Log, Enumerados.TipoLog.T.ToString());
        }

        public static void GrabarLogErrorArchivo(LogErrorBE Log)
        {
            ManejoLog.GrabarLogError((object)Log);
        }
    }

}
