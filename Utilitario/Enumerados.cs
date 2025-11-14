using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class Enumerados
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct LogCtrl
        {
            public enum NivelesErrorLog
            {
                E,
                I,
                W,
                D,
            }

            public enum TipoLog
            {
                A,
                T,
            }

            public enum OrigenError
            {
                AccesoDatos = 1,
                LogicaNegocios = 2,
                Presentacion = 3,
                WebService = 4,
            }
        }

        public enum NivelesErrorLog
        {
            E,
            I,
            W,
            D,
            C,
        }

        public enum TipoLog
        {
            A,
            T,
            E,
        }

        public enum OrigenError
        {
            AccesoDatos = 1,
            LogicaNegocios = 2,
            Presentacion = 3,
        }

        public enum CentroOperativo
        {
            SimaCallao = 1,
            SimaChimbote = 2,
            SimaIquitos = 3,
        }
    }
}
