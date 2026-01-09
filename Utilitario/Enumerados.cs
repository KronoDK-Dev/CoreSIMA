using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario
{
    public class Enumerados
    {
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
                WebService = 4,
                Presentacion = 3,
                LogicaNegocios = 2,
                AccesoDatos = 1,
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
            Presentacion = 3,
            LogicaNegocios = 2,
            AccesoDatos = 1,
        }

        public enum CentroOperativo
        {
            SimaCallao = 1,
            SimaChimbote = 2,
            SimaIquitos = 3
        }
    }
}
