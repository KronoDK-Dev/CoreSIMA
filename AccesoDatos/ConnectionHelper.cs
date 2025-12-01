using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccesoDatos
{
    public class ConnectionHelper
    {
        public static string GetOracleConnectionString(string connectionName)
        {
            string webConfigPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            XDocument webConfig = XDocument.Load(webConfigPath);

            var externalConfigPath = webConfig
                .Descendants("FileDBConectivity")
                .Descendants("add")
                .FirstOrDefault(x => (string)x.Attribute("key") == "ConfigDB")
                ?.Attribute("value")
                ?.Value;

            if (string.IsNullOrEmpty(externalConfigPath))
                throw new Exception("No se encontró la ruta del archivo externo de configuración (ConfigDB) en FileDBConectivity.");

            XDocument doc = XDocument.Load(externalConfigPath);

            var conn = doc.Descendants("add")
                .FirstOrDefault(x => (string)x.Attribute("name") == connectionName);

            if (conn == null)
                throw new Exception($"No se encontró la cadena de conexión '{connectionName}' en el archivo externo.");

            return conn.Attribute("connectionString").Value;
        }
    }
}
