using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Net;
using System.Security.Cryptography;
using Korbitec.Components.Messaging;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// General utilities and const used throughout the system
    /// </summary>
    public static class Utilities
    {
        #region date problems
        public static int DateToMinuteOfWeek(DateTime dt)
        {
            DateTime baseDate = GetDateOfPastSundayMorning();
            TimeSpan timediff = dt.Subtract(baseDate);

            return (int)timediff.TotalMinutes;
        }

        public static DateTime MinuteOfWeekToDate(int minOfWeek)
        {
            return GetDateOfPastSundayMorning().AddMinutes(minOfWeek);
        }

        public static DateTime GetDateOfPastSundayMorning()
        {
            return GetDateOfPastSundayMorning(DateTime.Now);
        }

        public static DateTime GetDateOfPastSundayMorning(DateTime dt)
        {
            DateTime calcDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);

            calcDate = calcDate.AddDays(DaysFromSunday(calcDate.DayOfWeek));

            return calcDate;
        }

        public static int DaysFromSunday(DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Sunday:
                    return 0;
                    break;
                case DayOfWeek.Monday:
                    return -1;
                    break;
                case DayOfWeek.Tuesday:
                    return -2;
                    break;
                case DayOfWeek.Wednesday:
                    return -3;
                    break;
                case DayOfWeek.Thursday:
                    return -4;
                    break;
                case DayOfWeek.Friday:
                    return -5;
                    break;
                case DayOfWeek.Saturday:
                    return -6;
                    break;
                default:
                    return 0;
            }
        }

        public static string UniqueID()
        {
            return NowDateToValidFilename();
        }

        #endregion Date Problems

        #region GC specific constants
        public const string SYSTEM_TEMPLATES = "System Templates";
        public const string GC_VERSION_FILENAME = "Version.txt";
        public const string GC_DEFAULT_VERSION = "0.0.0.0";
        public const string GC_BOND_TEMPLATES = "Bond Templates";
        public const string GC_DEVELOPMENT_TEMPLATES = "Development Templates";
        public const string GC_TRANSFER_TEMPLATES = "Transfer Templates";
        public const string GC_CONSENT_TEMPLATES = "Consent Templates";
        public const string GC_PROGRAMS = "Programs";
        public const string GC_UPDATE_BACKUP = "UpdateBackup";
        public const string GC_UPDATES = "Updates";
        public const string GC_BOOTSTRAP_EXE_NAME = "GhostConvey.exe";

        #endregion

        #region constants
        public const int MINS_IN_WEEK = 10080;
        public const int MINS_IN_DAY = 1440;
        public const string SERVICE_WAITFOR_TYPE_OTHER_THAN = "GSUpdateVPlugin";
        public const string PLUGIN_FILTER_NAME = "GhostServicePlugin*.DLL";
        public const string DLL_FILTER_NAME = "*.DLL";
        public const string EXE_FILTER_NAME = "*.EXE";
        public const string LOG_FILTER_NAME = "*.LOG";
        public const string ZIP_FILTER_NAME = "*.ZIP";
        public const string ZIP_EXT = ".ZIP";
        public const string LOG_EXT = ".LOG";
        public const string DB_SAVE_FILE = "GhostServiceSetup.exe.xml";
        public const string SERVICE_NAME = "GhostService.exe";
        public const string EVENTLOG_LOG_NAME = "Application";
        public const int MAX_MIN_WAIT_UPDATE = 60;
        public static TimeSpan _DefaultThreadTimeSpan = new TimeSpan(6, 0, 0); //6 hours?
        public static TimeSpan _DefaultThreadWorkerTimeSpan = new TimeSpan(15, 0, 0, 0); //15 days?
        public const string SQLSERVER_EMPTY_CONN_STRING = "Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;";
        public const string ACCESS_EMPTY_CONN_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}";
        public const string SQL_DATE_FORMAT = "yyyy-MM-dd";
        public const string SQL_FULL_DATE_FORMAT = "yyyyMMddHHmmssffff";
        //public const string UPDATE_NOTIFICATION_MSG = "Please note there is an update available for GhostConvey. ";
        public const int MIN_RANDOM_SEED = 1;//2;
        public const int MAX_RANDOM_SEED = 2;//15;
        public const string EMAIL_TEST_SUBJECT = "Test email (from GhostService)";
        public const string EMAIL_TEST_MESSAGE = "Test email created at: {0}";

        #endregion

        #region debug type stuff

        public static void LogText(string filename, string text)
        {
            StreamWriter sw = File.AppendText(filename);
            sw.WriteLine(text);
            sw.Close();
        }

        public static void DummyTestForm(int seconds, string title)
        {
            DummyTestForm(seconds, title, "");
        }
        
        public static void DummyTestForm(int seconds, string title, string message)
        {
            TestForm tf = new TestForm(seconds, title, message);
            tf.Text = title;
            tf.MaxTime = seconds;
            tf.ShowDialog();
            tf.Dispose();
        }
        #endregion

        #region paths

        public static string RelativePluginDirectory(string executingAssembly)
        {
            return Path.GetDirectoryName(executingAssembly);
        }

        public static string CallingAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
        }

        public static string RelativeServiceSetupFile(string executingAssembly)
        {
            string MyPath = Path.GetDirectoryName(executingAssembly);

            /*if (MyPath.Contains(_Plugins))
                return MyPath.Replace(_Plugins,_DBSaveFile);
            else*/
            return Path.Combine(MyPath, DB_SAVE_FILE);
        }

        public static string CurrentAssemblySettingFile(string assemblyName)
        {
            return string.Format("{0}.xml", assemblyName);
        }

        public static string CurrentAssemblyLogFile()
        {
            return string.Concat(Assembly.GetCallingAssembly().Location, NowDateToValidFilename(), Utilities.LOG_EXT);
        }

        private static string NowDateToValidFilename()
        {
            return DateToValidFilename(DateTime.Now);
        }

        private static string DateToValidFilename(DateTime date)
        {
            return date.ToString(SQL_FULL_DATE_FORMAT);
        }

        public static string PathToValidXMLName(string filePath)
        {
            string filePathResult = filePath;

            filePathResult = filePathResult.Replace('\\', '_');
            filePathResult = filePathResult.Replace('/', '_');
            filePathResult = filePathResult.Replace('.', '_');
            filePathResult = filePathResult.Replace(' ', '_');
            filePathResult = filePathResult.Replace(':', '_');

            return filePathResult;
        }

        #endregion

        #region XML goodies
        public static XmlWriterSettings _TheXMLSettings()
        {
            XmlWriterSettings settingsXML = new XmlWriterSettings();
            settingsXML.OmitXmlDeclaration = false;
            settingsXML.ConformanceLevel = ConformanceLevel.Auto;
            settingsXML.CloseOutput = false;
            settingsXML.Encoding = System.Text.Encoding.UTF8;
            settingsXML.Indent = true;

            return settingsXML;
        }
        #endregion

        #region Other, Zip, Proxy, Crypto, Email
                
        private static int t_keySize = 256; // can be 192 or 128

        public static WebProxy GetProxy(PluginServerInformation pluginServerInformation)
        {
            return GetProxy(pluginServerInformation.UseDefaultProxySettings,
                pluginServerInformation.ProxyCachedCredentials,
                pluginServerInformation.ProxyServer,
                pluginServerInformation.ProxyPort,
                pluginServerInformation.ProxyUserName,
                pluginServerInformation.ProxyPassword,
                pluginServerInformation.ProxyDomain);
        }
        
        public static WebProxy GetProxy(bool useDefault, bool useCacheCreds, string address, string port, string username, string password, string domain)
        {
            TraceLog.Log("Trying to create a proxy.");

            if (useDefault)
                return null;

            try
            {
                TraceLog.Log("Using manual proxy settings.");

                int myport = 8080;                
                try
                {
                    myport = Convert.ToInt32(port);
                }
                catch (Exception ex)
                {
                    myport = 8080;
                    TraceLog.Log(string.Format("Defaulting proxy port 8080, because:{0}", ex.ToString()));
                }

                TraceLog.Log(string.Format("Create proxy:{0}, {1}.", address, myport.ToString()));
                WebProxy webProxy = new WebProxy(address, myport);

                if (useCacheCreds)
                {
                    TraceLog.Log("Using default (cached) credentials."); 
                    webProxy.UseDefaultCredentials = true;                                       
                }
                else if (!string.IsNullOrEmpty(username))
                {
                    TraceLog.Log(string.Format("Create network credentials, User:{0}, Domain: {1}.", username, domain));
                    NetworkCredential credentials = new NetworkCredential(username, password, domain);
                    webProxy.Credentials = credentials;
                }
                
                //webProxy.BypassProxyOnLocal = true;
                
                return webProxy;
            }
            catch (Exception e)
            { 
                TraceLog.Log(string.Format("Proxy creation failed: {0}",e.ToString()));
                return null;
            }         
        }

        public static void UnzipFile(string zipFile, string rootUnzipPath)
        {
            if (!File.Exists(zipFile))
                throw new Exception("Cannot find file " + zipFile);

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    string targetDirectory = Path.Combine(rootUnzipPath/*Path.GetDirectoryName(zipFile)*/, directoryName);

                    Directory.CreateDirectory(targetDirectory);

                    if (fileName != String.Empty)
                    {                       
                        using (FileStream streamWriter = File.Create(Path.Combine(rootUnzipPath, theEntry.Name)))
                        {
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                    streamWriter.Write(data, 0, size);
                                else
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public static bool CheckZipFilesHasAccess(string zipFile, string rootUnzipPath, ref string lockedFiles)
        {
            if (!File.Exists(zipFile))
                throw new Exception("Cannot find file " + zipFile);

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    string targetDirectory = Path.Combine(rootUnzipPath/*Path.GetDirectoryName(zipFile)*/, directoryName);

                    if (fileName != String.Empty)
                    {
                        string targetFile = Path.Combine(rootUnzipPath, theEntry.Name);
                        if (File.Exists(targetFile))
                        {
                            try
                            {
                                using (FileStream streamWriter = File.Create(targetFile))
                                {
                                    streamWriter.Close();
                                }
                            }
                            catch
                            {
                                lockedFiles = string.Concat(lockedFiles, ",", targetFile);                            
                            }
                        }
                    }
                }
            }
            return (string.IsNullOrEmpty(lockedFiles));
        }
        
        public static void ZipFile(string zipFile, string fileName)
        {
            if (!File.Exists(fileName))
                throw new Exception("Cannot find file " + fileName);

            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFile)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];

                ZipEntry entry = new ZipEntry(Path.GetFileName(fileName));

                entry.DateTime = DateTime.Now;

                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(fileName))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
            }
        }

        #region cryto consts
        /// <summary>
        /// A dictionary attack is an attack in which the attacker attempts to decrypt an 
        /// encrypted message by comparing the encrypted value with previously computed 
        /// encrypted values for the most likely keys. This attack is made much more difficult
        /// by the introduction of random bytes at the end of the password before the key derivation.
        /// These random bytes are known as salt.
        /// </summary>
        private static string t_salt = "ServiceGhost"; // can be any string
        /// <summary>
        /// The Password for which to derive the key.
        /// </summary>
        private static string _passPhrase = "serviceghost";
        /// <summary>
        /// The name of the hash algorithm for the operation.
        /// </summary>
        private static string t_hashAlgorithm = "SHA1"; // can be "MD5" (Message Digest 5)
        /// <summary>
        /// The number of iterations for the operation.
        /// </summary>
        private static int t_passwordIterations = 2; // can be any number
        /// <summary>
        /// A nonsecret binary vector used as the initializing input algorithm 
        /// for the encryption of a plaintext block sequence to increase security by introducing 
        /// additional cryptographic variance and to synchronize any device that embodies 
        /// cryptographic logic or performs one or more cryptographic functions 
        /// (e.g. key generation, encryption, and authentication).
        /// </summary>
        private static string t_initVector = "51cgc5D4e5F6gbc43"; // must be 16 bytes (128 bit Encryption)
        /// <summary>
        /// Not quite sure yet, as to what this is for...
        /// </summary>
        #endregion

        public static string Encrypt(string plainText)
        {
            try
            {
                // ENCODE THE SPECIFIED SYSTEM.STRING INTO A BYTE ARRAY.
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(t_initVector);
                byte[] saltBytes = Encoding.ASCII.GetBytes(t_salt);

                // CONVERT THE PLAIN TEXT INTO AN ARRAY OF BYTES.
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                // PasswordDeriveBytes DERIVES A KEY FROM _passPhrase.
                PasswordDeriveBytes password = new PasswordDeriveBytes(_passPhrase,
                saltBytes,
                t_hashAlgorithm,
                t_passwordIterations);

                // RETURN PSEUDO-RANDOM KEY BYTES.
                byte[] keyBytes = password.GetBytes(t_keySize / 8);

                // INITIALIZE A NEW INSTANCE OF THE RijndaelManaged CLASS.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // SET THE MODE OF OPERATION FOR THE Symmetric Algorithm
                symmetricKey.Mode = CipherMode.CBC;

                // DEFINE THE BASIC OPERATIONS OF CRYPTOGRAPHIC TRANSFORMATIONS BY CREATING A SYMMETRIC 
                // System.Security.Cryptography.Rijndael ENCRYPTOR OBJECT WITH THE SPECIFIED
                // System.Security.Cryptography.SymmetricAlgorithm.Key
                // (keyBytes:The secret key to be used for the symmetric algorithm.) AND 
                // System.Security.Cryptography.SymmetricAlgorithm.IV
                // (initVectorBytes: The IV to be used for the symmetric algorithm.).
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                // MEMORYSTREAM CREATES A STREAM WHOSE BACKING STORE IS MEMORY.
                MemoryStream memoryStream = new MemoryStream();

                // INITIALIZE A NEW INSTANCE OF THE System.Security.Cryptography.CryptoStream CLASS WITH 
                // THE STREAM ON WHICH TO PERFORM THE CRYPTOGRAPHIC TRANSFORMATION(memoryStream),
                // THE CRYPTOGRAPHIC TRANSFORMATION THAT IS TO BE PERFORMED ON THE STREAM(encryptor),
                // AND THE MODE OF THE STREAM(CryptoStreamMode.Write). 
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                // WRITE THE SEQUENCE OF BYTES TO THE CURRENT System.Security.Cryptography.CryptoStream 
                // AND ADVANCE THE CURRENT POSITION WITHIN THE STREAM BY THE NUMBER OF BYTES WRITTEN. 
                // PARAMETERS:
                // buffer(plainTextBytes):An array of bytes. This method copies count bytes from buffer to the current stream.
                // offset(0):The byte offset in buffer at which to begin copying bytes to the current stream.
                // count(plainTextBytes.Length):The number of bytes to be written to the current stream.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                // UPDATE THE UNDERLYING DATA SOURCE OR REPOSITORY WITH THE CURRENT STATE OF THE BUFFER,
                // THEN CLEAR THE BUFFER.
                cryptoStream.FlushFinalBlock();

                // WRITE THE ENTIRE STREAM CONTENTS TO A BYTE ARRAY, REGARDLESS OF THE 
                // System.IO.MemoryStream.Position PROPERTY.
                byte[] cipherTextBytes = memoryStream.ToArray();

                // CLOSE THE STREAMS.
                memoryStream.Close();
                cryptoStream.Close();

                // CONVERT THE ARRAY OF 8-BIT UNSIGNED INTEGERS TO ITS EQUIVALENT System.String
                // REPRESENTATION CONSISTING OF BASE 64 DIGITS.
                string t_cipherText = Convert.ToBase64String(cipherTextBytes);

                // RETURN THE ENCRYPTED TEXT (CYPHER TEXT).
                return t_cipherText;
            }
            catch (Exception)
            {
                return "ENCRYPT Failed!";
            }
        }
               
        public static string Decrypt(string cipherText)
        {

            if (!String.IsNullOrEmpty(cipherText))
            {
                try
                {
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(t_initVector);
                    byte[] saltBytes = Encoding.ASCII.GetBytes(t_salt);
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                    PasswordDeriveBytes password = new PasswordDeriveBytes(_passPhrase,
                    saltBytes,
                    t_hashAlgorithm,
                    t_passwordIterations);

                    byte[] keyBytes = password.GetBytes(t_keySize / 8);
                    RijndaelManaged symmetricKey = new RijndaelManaged();

                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                    memoryStream.Close();
                    cryptoStream.Close();

                    string t_plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                    return t_plainText;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        public static bool SendTestEmail(PluginServerInformation pluginServerInformation, string emailTo)
        {
            return SendEmail(pluginServerInformation.UseMAPI,
                    pluginServerInformation.SMTPServer,
                    pluginServerInformation.SMTPDefaultFromAddress,
                    pluginServerInformation.SMTPUsername,
                    pluginServerInformation.SMTPPassword,
                    pluginServerInformation.SMTPSecureConnection,
                    string.Format(Utilities.EMAIL_TEST_MESSAGE,DateTime.Now.ToString()),
                    Utilities.EMAIL_TEST_SUBJECT, emailTo);
        }

        public static bool SendEmail(PluginServerInformation pluginServerInformation, string emailMessage, string emailSubject, string emailTo)
        {            
            return SendEmail(pluginServerInformation.UseMAPI,
                    pluginServerInformation.SMTPServer,
                    pluginServerInformation.SMTPDefaultFromAddress,
                    pluginServerInformation.SMTPUsername,
                    pluginServerInformation.SMTPPassword,
                    pluginServerInformation.SMTPSecureConnection,
                    emailMessage,emailSubject,emailTo);
        }

        public static bool SendEmail(bool useMAPI, string sMTPServer, string defaultFromAddress, string sMTPUsername, string sMTPPassword, bool secureConnection, string emailMessage, string emailSubject, string emailTo)
        {            
            Email email = new Email();
            email.To = emailTo;
            email.Subject = emailSubject;
            email.Message = emailMessage;
            
            if (useMAPI)
            {
                EmailerOutlook emailerOutLook = new EmailerOutlook();
                emailerOutLook.SendEmail(email);                
            }
            else
            {   
                EmailerSmtp emailerSmtp = new EmailerSmtp(defaultFromAddress,sMTPServer);
                emailerSmtp.SmtpSecureConnection = secureConnection;
                emailerSmtp.SmtpUserName = sMTPUsername;
                emailerSmtp.SmtpPassword = sMTPPassword;

                emailerSmtp.SendEmail(email);
            }

            return true;
        }
        
        #endregion

        /* testing 
        public static TimeSpan _59Secs = new TimeSpan(0, 0, 0, 59); 
        */
    }
}
