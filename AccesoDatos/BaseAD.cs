using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Utilitario;

namespace AccesoDatos
{
    public class BaseAD
    {
        public static Database DBGeneric(Enumerados.CentroOperativo IdCentroOperativo)
        {
            switch (IdCentroOperativo)
            {
                case Enumerados.CentroOperativo.SimaCallao:
                    return BaseAD.Oracle(BaseAD.ORACLEVersion.O7);
                case Enumerados.CentroOperativo.SimaChimbote:
                    return BaseAD.Sql(BaseAD.SQLVersion.sqlDBSimaCH);
                case Enumerados.CentroOperativo.SimaIquitos:
                    return BaseAD.Sql(BaseAD.SQLVersion.sqlDBSimaIQ);
                default:
                    return (Database)null;
            }
        }

        public static Database DBGeneric(BaseAD.SQLVersion sqlDB) => BaseAD.Sql(sqlDB);

        public static Database DBGeneric(BaseAD.ORACLEVersion sqlDB) => BaseAD.Oracle(sqlDB);

        public static Database DBGeneric(BaseAD.OLEDBVersion sqlDB) => BaseAD.OleDb(sqlDB);

        public static Database Sql(BaseAD.SQLVersion dbVer) => BaseAD.BasedeDatos(dbVer.ToString());

        public static Database Oracle(BaseAD.ORACLEVersion dbVer) => BaseAD.BasedeDatos(dbVer.ToString());

        public static Database OleDb(BaseAD.OLEDBVersion dbVer) => BaseAD.BasedeDatos(dbVer.ToString());

        public static Database MySQL(BaseAD.MySQLVersion dbVer) => BaseAD.BasedeDatos(dbVer.ToString());

        private static Database BasedeDatos(string tagConexionDB)
        {
            return new DatabaseProviderFactory((IConfigurationSource)new FileConfigurationSource(BaseAD.Configuracion.BaseDatos.NombreArchivo)).Create(tagConexionDB.ToUpper());
        }

        public InfoMetodoBE MetodoInfo(string NombreMetodo, params string[] Valores)
        {
            InfoMetodoBE infoMetodoBe = new InfoMetodoBE();
            string str1 = "[M]([P])".Replace("[M]", NombreMetodo);
            Type type = this.GetType();
            string newValue = "";
            MethodBase method;
            try
            {
                method = (MethodBase)type.GetMethod(NombreMetodo);
            }
            catch (Exception ex)
            {
                method = (MethodBase)type.GetMethod(NombreMetodo, BindingFlags.Instance | BindingFlags.Public, (Binder)null, CallingConventions.Any, new Type[2]
                {
        typeof (int),
        typeof (int)
                }, (ParameterModifier[])null);
            }
            if (method == (MethodBase)null)
                return infoMetodoBe;
            infoMetodoBe.FullName = method.DeclaringType.FullName;
            string str2 = "";
            int index = 0;
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                newValue = $"{newValue}{(index == 0 ? "" : ",")}{parameter.ParameterType?.ToString()} {parameter.Name}";
                if (Valores.Length != 0)
                {
                    if (parameter.ParameterType.Name == "BaseBE")
                        str2 = $"{str2}{(index == 0 ? "" : ",")}{parameter.Name}:{{{string.Join(",", Valores)}}}";
                    else
                        str2 = $"{str2}{(index == 0 ? "" : ",")}{parameter.Name}:'{Valores[index]}'";
                }
                ++index;
            }
            infoMetodoBe.MetodoANDParams = str1.Replace("[P]", newValue);
            infoMetodoBe.VoidParams = $"{{{str2}}}";
            return infoMetodoBe;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Configuracion
        {
            private static string NombreSeccion => "FileDBConectivity";

            [StructLayout(LayoutKind.Sequential, Size = 1)]
            public struct BaseDatos
            {
                private static string KeyFileDB => "ConfigDB";

                public static string NombreArchivo
                {
                    get
                    {
                        return ((Hashtable)ConfigurationManager.GetSection(BaseAD.Configuracion.NombreSeccion))[(object)BaseAD.Configuracion.BaseDatos.KeyFileDB].ToString();
                    }
                }
            }
        }

        public enum SQLVersion
        {
            sqlSIMANET,
            sql2019,
            sqlSeguridad,
            sqlSistrades,
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
            oMySql,
        }

        public enum OLEDBVersion
        {
            oledb,
        }
    }
}
