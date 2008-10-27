using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A DB, can be mdb or config file
    /// </summary>
    public class Db
    {
        public Db(string configFilePath)
        {
            ConfigFilePath = configFilePath;
        }

        public string ConfigFilePath
        { get; set; }
        private XmlDocument _xmlDoc;

        private string GetConfigSetting(string keyName, ref string localVariable)
        {
            if (localVariable == null)
            {
                if (IsSQLModule)
                {
                    if (_xmlDoc == null)
                    {
                        using (StreamReader stream = new StreamReader(ConfigFilePath))
                        {
                            string xml = stream.ReadToEnd();
                            _xmlDoc = new XmlDocument();
                            _xmlDoc.LoadXml(xml);
                        }
                    }

                    XmlNode xmlNode = null;
                    foreach (XmlNode node in _xmlDoc.ChildNodes)
                    {
                        if (node.NodeType != XmlNodeType.Comment)
                        {
                            xmlNode = node.ChildNodes[0].SelectSingleNode(keyName);
                            break;
                        }
                    }

                    if (xmlNode == null)
                        throw new InvalidDBConfigFileException(ConfigFilePath);
                    localVariable = xmlNode.InnerText;

                    if (keyName == "Password")
                    {
                        if (LooksEncrypted(localVariable))
                            localVariable = DecryptPassword();
                    }
                }
                else
                {
                    if (keyName == "Database")
                        localVariable = ConfigFilePath;
                    else
                        localVariable = "";
                }
            }

            return localVariable;
        }

        class InvalidDBConfigFileException : Exception
        {
            public InvalidDBConfigFileException(String Information)
                : base("Invalid database config file: " + Information)
            {
            }
        }

        private string DecryptPassword()
        {
            //re-read the bytes from the file as the xml string does not contain the actual bytes
            byte[] xmlBytes;
            using (FileStream stream = new FileStream(ConfigFilePath, FileMode.Open))
            {
                xmlBytes = new byte[stream.Length];
                stream.Read(xmlBytes, 0, xmlBytes.Length);
            }

            //look for <Password> in the bytes
            byte[] password = new byte[0];
            for (int i = 0; i < xmlBytes.Length - 10; i++)
            {
                if ((xmlBytes[i] == (byte)'<') &&
                    (xmlBytes[i + 1] == (byte)'P') &&
                    (xmlBytes[i + 2] == (byte)'a') &&
                    (xmlBytes[i + 3] == (byte)'s') &&
                    (xmlBytes[i + 4] == (byte)'s') &&
                    (xmlBytes[i + 5] == (byte)'w') &&
                    (xmlBytes[i + 6] == (byte)'o') &&
                    (xmlBytes[i + 7] == (byte)'r') &&
                    (xmlBytes[i + 8] == (byte)'d') &&
                    (xmlBytes[i + 9] == (byte)'>'))
                {
                    int j = i + 10;
                    int length = 0;
                    for (int k = j; k < xmlBytes.Length; k++)
                    {
                        if (xmlBytes[k] == (byte)'<')
                        {
                            length = k - j;
                            break;
                        }
                    }
                    if (length == 0)
                        throw new InvalidDBConfigFileException(ConfigFilePath);
                    password = new byte[length];
                    for (int k = 0; k < length; k++)
                    {
                        password[k] = xmlBytes[j + k];
                    }
                    break;
                }
            }
            if (password.Length == 0)
                throw new InvalidDBConfigFileException(ConfigFilePath);

            //decrypt the password
            string result = "";
            byte mask = (byte)((password.Length % 256) | 128);
            foreach (byte b in password)
            {
                result += (char)(b ^ mask);
            }
            return result;
        }

        private bool LooksEncrypted(string localVariable)
        {
            foreach (char c in localVariable)
            {
                if ((byte)c < 32 || (byte)c > 126)
                    return true;
            }
            return false;
        }

        private string _serverName;
        public string ServerName
        {
            get
            {
                return GetConfigSetting("Server", ref _serverName);
            }
        }

        private string _dbName;
        public string DbName
        {
            get
            {
                return GetConfigSetting("Database", ref _dbName);
            }
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return GetConfigSetting("User", ref _userName);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return GetConfigSetting("Password", ref _password);
            }
        }

        private bool? _isSQLModule;
        public bool IsSQLModule
        {
            get
            {
                if (_isSQLModule == null)
                    _isSQLModule = File.Exists(ConfigFilePath) && ConfigFilePath.Contains(".cfg");
                return (bool)_isSQLModule;
            }
        }

        private string _ConnectionStr;
        public string ConnecitonStr
        {
            get
            {
                if (IsSQLModule)
                    return string.Format(Utilities.SQLSERVER_EMPTY_CONN_STRING, this.ServerName, this.DbName, this.UserName, this.Password);
                else
                    return string.Format(Utilities.ACCESS_EMPTY_CONN_STRING, this.DbName);
            }
        }

    }
}
