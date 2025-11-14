using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ManejadorException;
using Utilitario;

namespace Log
{
    public class ManejoLog : LogBE
    {
        private static string FechaLog;
        private static string FechaLogError;
        private static string ListenerTransaccional;
        private static string ListenerAplicativo;
        private static TextWriterTraceListener FileListenerTransaccional;
        private static TextWriterTraceListener FileListenerAplicativo;
        private static TextWriterTraceListener FileListenerErrorAplicativo;
        private static string ListenerAplicativoError;
        private static string DirectorioLog;

        private static void VerificaFechaLog()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string str = dateTime.ToString(Constante.Formato.Fecha.yyyyMMdd);
            if (!(ManejoLog.FechaLog != str))
                return;
            ManejoLog.CierraLogs();
            ManejoLog.AbreLogs();
        }

        private static void VerificaFechaLogError()
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            string str = dateTime.ToString(Constante.Formato.Fecha.yyyyMMdd);
            if (!(ManejoLog.FechaLogError != str))
                return;
            ManejoLog.CierraLogsError();
            ManejoLog.AbreLogsError();
        }

        public static void AbreLogs()
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                ManejoLog.DirectorioLog = LogBE.RutaLog;
                ManejoLog.FechaLog = DateTime.Now.Date.ToString(Constante.Formato.Fecha.yyyyMMdd);
                ManejoLog.ListenerTransaccional = Constante.Archivo.Prefijo.LOGTRANSACCIONAL + ManejoLog.FechaLog;
                ManejoLog.ListenerAplicativo = Constante.Archivo.Prefijo.LOGAPLICATIVO + ManejoLog.FechaLog;
                ManejoLog.FileListenerTransaccional = new TextWriterTraceListener(ManejoLog.DirectorioLog + ManejoLog.ListenerTransaccional + Constante.Archivo.Extension.TXT, ManejoLog.ListenerTransaccional);
                ManejoLog.FileListenerAplicativo = new TextWriterTraceListener(ManejoLog.DirectorioLog + ManejoLog.ListenerAplicativo + Constante.Archivo.Extension.TXT, ManejoLog.ListenerAplicativo);
                Trace.Listeners.Add((TraceListener)ManejoLog.FileListenerTransaccional);
                Trace.Listeners.Add((TraceListener)ManejoLog.FileListenerAplicativo);
            }
            catch (Exception ex)
            {
                throw ManejoExcepcion.CrearSIMAExcepcionLog(Constante.Archivo.Prefijo.CODIGOERRORLOG, ex.Message);
            }
        }

        public static void CierraLogs()
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                Trace.Listeners.Remove((TraceListener)ManejoLog.FileListenerTransaccional);
                Trace.Listeners.Remove((TraceListener)ManejoLog.FileListenerAplicativo);
                if (ManejoLog.FileListenerTransaccional != null)
                    ManejoLog.FileListenerTransaccional.Close();
                if (ManejoLog.FileListenerAplicativo == null)
                    return;
                ManejoLog.FileListenerAplicativo.Close();
            }
            catch
            {
            }
        }

        public static void AbreLogsError()
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                ManejoLog.DirectorioLog = LogBE.RutaLog;
                ManejoLog.FechaLogError = DateTime.Now.Date.ToString(Constante.Formato.Fecha.yyyyMMdd);
                ManejoLog.ListenerAplicativoError = Constante.Archivo.Prefijo.LOGAPLICATIVOERROR + ManejoLog.FechaLogError;
                ManejoLog.FileListenerErrorAplicativo = new TextWriterTraceListener(ManejoLog.DirectorioLog + ManejoLog.ListenerAplicativoError + Constante.Archivo.Extension.TXT, ManejoLog.ListenerAplicativoError);
                Trace.Listeners.Add((TraceListener)ManejoLog.FileListenerErrorAplicativo);
            }
            catch (Exception ex)
            {
                throw ManejoExcepcion.CrearSIMAExcepcionLog(Constante.Archivo.Prefijo.CODIGOERRORLOG, ex.Message);
            }
        }

        public static void CierraLogsError()
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                Trace.Listeners.Remove((TraceListener)ManejoLog.FileListenerErrorAplicativo);
                if (ManejoLog.FileListenerErrorAplicativo == null)
                    return;
                ManejoLog.FileListenerErrorAplicativo.Close();
            }
            catch
            {
            }
        }

        public static void GrabarLog(object MensajeLog, string TipoLog)
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                ManejoLog.VerificaFechaLog();
                switch ((Enumerados.TipoLog)Enum.Parse(typeof(Enumerados.TipoLog), TipoLog))
                {
                    case Enumerados.TipoLog.A:
                        Trace.Listeners[ManejoLog.ListenerAplicativo].WriteLine(MensajeLog);
                        break;
                    case Enumerados.TipoLog.T:
                        Trace.Listeners[ManejoLog.ListenerTransaccional].WriteLine(MensajeLog);
                        break;
                }
                Trace.Flush();
            }
            catch (Exception ex)
            {
                throw ManejoExcepcion.CrearSIMAExcepcionLog(Constante.Archivo.Prefijo.CODIGOERRORLOG + "00001", ex.Message);
            }
        }

        public static void GrabarLogError(object MensajeLog)
        {
            if (!ManejoLog.LogFile.VerificaEstadoGrabarLog)
                return;
            try
            {
                ManejoLog.VerificaFechaLogError();
                Trace.Listeners[ManejoLog.ListenerAplicativoError].WriteLine(MensajeLog.ToString());
                Trace.Flush();
            }
            catch (Exception ex)
            {
                throw ManejoExcepcion.CrearSIMAExcepcionLog(Constante.Archivo.Prefijo.CODIGOERRORLOG + "00001", ex.Message);
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct LogFile
        {
            private const string SeccionConfig = "LogSeccion";
            private const string FlagEstado = "LogEncendido";

            public static bool VerificaEstadoGrabarLog
            {
                get
                {
                    return Convert.ToBoolean(((Hashtable)ConfigurationManager.GetSection("LogSeccion"))[(object)"LogEncendido"].ToString());
                }
            }
        }
    }
}
