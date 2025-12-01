using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.Seguridad
{
    public class AD
    {
        #region VARIABLES

        public string cadenaLDAP = String.Empty;

        private DirectoryEntry dEntry;
        private DirectorySearcher dSearch;

        #endregion
        #region CONSTRUCTOR

        public AD(string LDAP)
        {
            cadenaLDAP = LDAP;
            dEntry = new DirectoryEntry(LDAP);
            dSearch = new DirectorySearcher(dEntry);
        }
        public AD() { }

        #endregion

        public bool ValidarUsuario(string userAccount, string userPassword)
        {
            try
            {
                DirectoryEntry dEntryValidation = new DirectoryEntry(cadenaLDAP);
                dEntryValidation.Username = userAccount;
                dEntryValidation.Password = userPassword;
                dEntryValidation.AuthenticationType = AuthenticationTypes.Secure;
                dEntryValidation.RefreshCache();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteUsuario(string userAccount)
        {
            dSearch.Filter = "(&(objectClass=user) (samaccountname=" + userAccount + "))";
            SearchResultCollection results = dSearch.FindAll();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
