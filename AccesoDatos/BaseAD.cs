using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AccesoDatos
{
    public class BaseAD
    {
        public struct Configuracion
        {
            #region Privados
            private static string NombreSeccion
            {
                get { return "FileDBConectivity"; }
            }
            #endregion

            public struct BaseDatos
            {
                #region Privados
                private static string KeyFileDB
                {
                    get { return "ConfigDB"; }
                }
                #endregion
                #region Publicos
                public static string NombreArchivo
                {
                    get { return ((Hashtable)ConfigurationManager.GetSection(Configuracion.NombreSeccion))[Configuracion.BaseDatos.KeyFileDB].ToString(); }
                }
                #endregion
            }
        }

        public enum SQLVersion
        {
            sqlSIMANET,
            sql2019,
            sqlSeguridad,
            sqlSistrades,
            /*Para la facturacion electronica*/
            sqlDBSimaCH,
            sqlDBSimaIQ,
        }
        public enum ORACLEVersion
        {
            o9i,
            o73,
            o11g,
            UNISYS,
            oJDE,
            O7,
        }
        public enum MySQLVersion
        {
            oMySql
        }
        public enum OLEDBVersion
        {
            oledb,
        }


        public static Database DBGeneric(Utilitario.Enumerados.CentroOperativo IdCentroOperativo)
        {
            if (IdCentroOperativo == Utilitario.Enumerados.CentroOperativo.SimaCallao)
            {
                return Oracle(ORACLEVersion.O7);
            }
            else if (IdCentroOperativo == Utilitario.Enumerados.CentroOperativo.SimaChimbote)
            {
                return Sql(SQLVersion.sqlDBSimaCH);
            }
            else if (IdCentroOperativo == Utilitario.Enumerados.CentroOperativo.SimaIquitos)
            {
                return Sql(SQLVersion.sqlDBSimaIQ);
            }
            return null;
        }




        public static Database DBGeneric(SQLVersion sqlDB)
        {
            return Sql(sqlDB);
        }
        public static Database DBGeneric(ORACLEVersion sqlDB)
        {
            return Oracle(sqlDB);
        }
        public static Database DBGeneric(OLEDBVersion sqlDB)
        {
            return OleDb(sqlDB);
        }



        public static Database Sql(SQLVersion dbVer)
        {
            return BasedeDatos(dbVer.ToString());
        }

        public static Database Oracle(ORACLEVersion dbVer)
        {
            return BasedeDatos(dbVer.ToString());
        }


        public static Database OleDb(OLEDBVersion dbVer)
        {
            return BasedeDatos(dbVer.ToString());
        }
        public static Database MySQL(MySQLVersion dbVer)
        {
            return BasedeDatos(dbVer.ToString());
        }

        private static Database BasedeDatos(string tagConexionDB)
        {
            FileConfigurationSource dataSource = new FileConfigurationSource(Configuracion.BaseDatos.NombreArchivo);
            DatabaseProviderFactory dbFactory = new DatabaseProviderFactory(dataSource);
            Database db = dbFactory.Create(tagConexionDB.ToUpper());
            return db;
        }

        #region metodos privados
        public InfoMetodoBE MetodoInfo(string NombreMetodo, params string[] Valores)
        {
            InfoMetodoBE oInfoMetodoBE = new InfoMetodoBE();
            string Metodo = "[M]([P])";
            Metodo = Metodo.Replace("[M]", NombreMetodo);
            Type MyType = this.GetType();
            MethodBase Mymethodbase;
            string ParamValor = "";
            try
            {
                Mymethodbase = MyType.GetMethod(NombreMetodo);
            }
            catch (Exception ex)
            {
                Mymethodbase = MyType.GetMethod(NombreMetodo, BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.Any, new Type[] { typeof(int), typeof(int) }, null);
            }



            if (Mymethodbase == null) { return oInfoMetodoBE; }

            oInfoMetodoBE.FullName = Mymethodbase.DeclaringType.FullName;

            string _SoloParams = "";
            int idx = 0;
            foreach (ParameterInfo ParamMetod in Mymethodbase.GetParameters())
            {
                ParamValor += ((idx == 0) ? "" : ",") + ParamMetod.ParameterType + " " + ParamMetod.Name;
                if (Valores.Length > 0)
                {
                    if (ParamMetod.ParameterType.Name == "BaseBE")
                    {
                        _SoloParams += ((idx == 0) ? "" : ",") + ParamMetod.Name + ":" + "{" + string.Join(",", Valores) + "}";
                    }
                    else
                    {
                        _SoloParams += ((idx == 0) ? "" : ",") + ParamMetod.Name + ":" + "'" + Valores[idx] + "'";
                    }
                }
                idx++;
            }
            oInfoMetodoBE.MetodoANDParams = Metodo.Replace("[P]", ParamValor);
            oInfoMetodoBE.VoidParams = "{" + _SoloParams + "}";
            return oInfoMetodoBE;
        }

        #endregion








    }
}
