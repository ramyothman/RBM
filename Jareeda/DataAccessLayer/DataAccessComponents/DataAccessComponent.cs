using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace DataAccessLayer.DataAccessComponents
{
    public enum DatabaseType
    {
        SQLServer,
        Oracle,
        MySQL
    }
    public class DataAccessComponent
    {

        #region Constructors
        public DataAccessComponent(string connectionStringKey,params string[] tableNames)
        {
            if(!string.IsNullOrEmpty(connectionStringKey))
                database = DatabaseFactory.CreateDatabase(connectionStringKey);
            foreach (string str in tableNames) 
            {
                if(!string.IsNullOrEmpty(str))
                    TableNames.Add(str);
            }
        }
        public DataAccessComponent(string connectionStringKey)
        {
            database = DatabaseFactory.CreateDatabase(connectionStringKey);
        }
        public DataAccessComponent(string connectionString, DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.MySQL:
                    break;
                case DatabaseType.Oracle:
                    break;
                case DatabaseType.SQLServer:
                    database = null;
                    Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase db = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connectionString);
                    database = db;
                    break;
            }
        }
        #endregion

        #region Properties

        private List<string> _TableName = new List<string>();
        public List<string> TableNames
        {
            set
            {
                _TableName = value;
            }
            get
            {
                return _TableName;
            }
        }
        public static string ConfigPath
        {
            get
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Web.config");
                if (IsDesktop)
                {
                    path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                }
                return path;
            }
        }
        public static bool IsDesktop
        {
            get
            {
                bool result = false;
                if (System.Configuration.ConfigurationManager.AppSettings.Get("IsDesktop") == "true")
                    result = true;
                return result;
            }
        }
        public static string ApplicationSettingsPath
        {
            get
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/_Settings/AppSettings.config");
                if (IsDesktop)
                {
                    path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                }
                return path;
            }
        }
        private Database database = null;
        public Database Database
        {
            get 
            {
                if (database == null)
                {
                    if (System.Configuration.ConfigurationManager.AppSettings["ConnectionEncrypted"] != "True")
                    {
                        string connPlain = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
                        string connEncrypted = Encrypt(connPlain);
                        database = DatabaseFactory.CreateDatabase("MainDB");
                        string path = System.Web.HttpContext.Current.Server.MapPath("~/Web.config");
                        UpdateConfigConnectionKey(path, "MainDB", connEncrypted, "True");
                    }
                    else
                    {
                        string connEncrypted = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
                        string conn = Decrypt(connEncrypted);
                        database = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(conn);
                    }

                }
                return database; 
            }
        }
        #endregion

        #region Methods
        public System.Data.SqlClient.SqlDataReader SelectStatement(string query)
        {
            System.Data.IDataReader dr = Database.ExecuteReader(CommandType.Text, query);
            return (System.Data.SqlClient.SqlDataReader)dr;
        }
        public int EXQuery(string query)
        {
            return Database.ExecuteNonQuery(CommandType.Text, query);
        }

        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZPA@CE7T");

        public static string Encrypt(string originalString)
        {
            //MessageBox.Show("Before Encrypt 1");
            if (string.IsNullOrEmpty(originalString)) return "";
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            //   MessageBox.Show("after stream writer");
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

        }

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            if (cryptedString.Contains(" "))
                return cryptedString;
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream ;
            try
            {
                memoryStream = new MemoryStream
                        (Convert.FromBase64String(cryptedString));
            }
            catch (Exception ex)
            {
                return cryptedString;
            }
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        

        public void UpdateConfigConnectionKey(string xmlPath,string strKey, string newValue,string appKeyValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/connectionStrings");
            foreach (XmlNode childNode in appSettingsNode)
            {
                if(childNode.Attributes != null)
                    if (childNode.Attributes["name"].Value == strKey)
                        childNode.Attributes["connectionString"].Value = newValue;
            }
            xmlDoc.Save(xmlPath);
            xmlDoc = new XmlDocument();
            xmlDoc.Load(ApplicationSettingsPath);
            appSettingsNode = xmlDoc.SelectSingleNode("appSettings");
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes != null)
                    if (childNode.Attributes["key"].Value == "ConnectionEncrypted")
                        childNode.Attributes["value"].Value = appKeyValue;
            }
            xmlDoc.Save(ApplicationSettingsPath);

            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            string strApp = System.Configuration.ConfigurationManager.AppSettings["ConnectionEncrypted"];
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
        #endregion

    }
}
