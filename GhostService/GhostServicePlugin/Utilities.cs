using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;

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

        #region Other, Zip
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
        #endregion

        /* testing 
        public static TimeSpan _59Secs = new TimeSpan(0, 0, 0, 59); 
        */
    }
}
