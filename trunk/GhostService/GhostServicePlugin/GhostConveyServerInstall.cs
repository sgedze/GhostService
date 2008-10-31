using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Threading;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A GC server install, can get all information regarding the install.
    /// </summary>
    public class GhostConveyServerInstall : Db
    {
        public GhostConveyServerInstall(string configFilePath)
            : base(configFilePath)
        { }

        public string ConfigReference
        {
            get
            {
                return Utilities.PathToValidXMLName(this.ConfigFilePath);
            }
        }
        
        public string GCSystemTemplatesFolder
        {
            get
            {
                if (IsSQLModule)
                { return Path.GetDirectoryName(ConfigFilePath); }
                else
                { return Path.Combine(Path.GetDirectoryName(ConfigFilePath), Utilities.SYSTEM_TEMPLATES); }
            }
        }

        public string GCDataFolder
        {
            get
            {
                if (IsSQLModule)
                { return Path.Combine(Path.GetDirectoryName(ConfigFilePath), ".."); }
                else
                { return Path.GetDirectoryName(ConfigFilePath); }
            }
        }

        public Version GCVersionFromFile
        {
            get
            {
                string version;
                if (File.Exists(GCVersionFilePath))
                    version = File.ReadAllText(GCVersionFilePath);
                else
                    version = Utilities.GC_DEFAULT_VERSION;

                Version v = new Version(version);

                return v;
            }
        }

        public string GCVersionFilePath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_VERSION_FILENAME); }
        }

        public string GCBondTemplatePath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_BOND_TEMPLATES); }
        }

        public string GCDevelopmentTemplatePath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_DEVELOPMENT_TEMPLATES); }
        }

        public string GCTranferTemplatePath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_TRANSFER_TEMPLATES); }
        }

        public string GCConcentTemplatePath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_CONSENT_TEMPLATES); }
        }

        public string GCProgramsPath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_PROGRAMS); }
        }

        public string GCUpdateBackupPath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_UPDATE_BACKUP); }
        }

        public string GCUpdatesPath
        {
            get { return Path.Combine(GCDataFolder, Utilities.GC_UPDATES); }
        }

        public string GCBootStrapExePath
        {
            get { return Path.Combine(GCProgramsPath, Utilities.GC_BOOTSTRAP_EXE_NAME); }
        }

        private List<String> GetNotifyUserList()
        {
            string sql;
            Version fromVersion;
            GhostConveySQLs.GC_USR_punters_GetNotifyUserListSQL(out sql, out fromVersion);

            if (!SQLCanRun(fromVersion))
                return null;

            DataTable datatable = RunQuery(sql);

            List<String> UserList = new List<string>();

            foreach (DataRow datarow in datatable.Rows)
            {
                UserList.Add(datarow["LogonName"].ToString());
            }

            return UserList;
        }

        public string GCLicenseCode
        {
            get { return GetLicenseCode(); }
        }
        private string GetLicenseCode()
        {
            string sql;

            GhostConveySQLs.GC_USR_firm_GetLicenseSQL(out sql);

            return RunQueryStr(sql);
        }

        public void WriteNotificationMsgToUserList(string msg)
        {
            if (GetNotifyUserList() != null)
            {
                TraceLog.Log(string.Format("Attempt sending messages({1}) to {0} GC users",GetNotifyUserList().Count,msg));
                WriteMsgToUserList(msg, GetNotifyUserList());
                TraceLog.Log("Messages sent.");
            }
            else
                TraceLog.Log("Select some users in setup to received update notifications.");
        }

        public void WriteMsgToUserList(string msg, List<string> userList)
        {
            String sql;
            Version fromVersion;

            foreach (string s in userList)
            {              
                GhostConveySQLs.GC_USR_UserMessages_InsertMsgSQL(out sql, out fromVersion,
                                        DateTime.Now.ToString(Utilities.SQL_FULL_DATE_FORMAT),
                                        DateTime.Now.ToString(Utilities.SQL_DATE_FORMAT),
                                        s, msg, Utilities.SERVICE_NAME);

                if (!SQLCanRun(fromVersion))
                    return;

                ExecuteQuery(sql);

                //Believe it or not it runs that fast
                Thread.Sleep(1);
            }
        }

        public bool SQLCanRun(Version version)
        {
            return version <= GCVersionFromFile;
        }

        public bool CopyUpdateToGCUpdateFolder(string updateFileName)
        {
            bool Success = true;

            try
            {
                File.Copy(updateFileName, Path.Combine(GCUpdatesPath, Path.GetFileName(updateFileName)), true);
            }
            catch (Exception e)
            {
                Success = false;
            }

            return Success;
        }

        public string FindFirstFilePath(string fileName)
        {
            return FindFilePath(fileName, true)[0];
        }

        public List<string> FindFilePath(string fileName)
        {
            return FindFilePath(fileName, false);
        }

        private List<string> FindFilePath(string fileName, bool onlyOne)
        {
            List<string> files = new List<string>();

            foreach (string s in GCSearchPaths)
            {
                files.AddRange(Directory.GetFiles(s, fileName));
                if (files.Count > 1)
                    break;
            }

            return files;
        }

        private List<string> GCSearchPaths
        {
            get
            {
                List<string> gcsearchpaths = new List<string>();

                gcsearchpaths.Add(GCBondTemplatePath);
                gcsearchpaths.Add(GCDevelopmentTemplatePath);
                gcsearchpaths.Add(GCTranferTemplatePath);
                gcsearchpaths.Add(GCConcentTemplatePath);
                gcsearchpaths.Add(GCProgramsPath);
                gcsearchpaths.Add(GCDataFolder);
                gcsearchpaths.Add(GCSystemTemplatesFolder);
                gcsearchpaths.Add(GCUpdatesPath);
                gcsearchpaths.Add(GCUpdateBackupPath);

                return gcsearchpaths;
            }
        }

        public void ApplyZippedUpdate(string downloadFilePath)
        {
            string lockedFiles = "";
            
            if (Utilities.CheckZipFilesHasAccess(downloadFilePath, GCDataFolder, ref lockedFiles))
                Utilities.UnzipFile(downloadFilePath, GCDataFolder);
            else
                throw new Exception(String.Format("This following files cannot be opened or overwritten:{0}",lockedFiles));
        }

        private DbConnection _conn;
        public DbConnection conn
        {
            get
            {
                if (_conn == null)
                {
                    if (IsSQLModule)
                        _conn = new SqlConnection();
                    else
                        _conn = new OleDbConnection();
                }
                _conn.Close();

                _conn.ConnectionString = this.ConnecitonStr;

                return _conn;
            }
        }

        public DataTable RunQuery(String sql)
        {
            conn.Open();

            DataSet dataset = new DataSet("this");

            if (IsSQLModule)
            {
                SqlCommand com = new SqlCommand(sql, (SqlConnection)conn);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.TableMappings.Add("Table", "this");
                adapter.Fill(dataset);
            }
            else
            {
                OleDbCommand comAccess = new OleDbCommand(sql, (OleDbConnection)conn);
                OleDbDataAdapter adapterAccess = new OleDbDataAdapter(comAccess);
                adapterAccess.TableMappings.Add("Table", "this");
                adapterAccess.Fill(dataset);
            }

            return dataset.Tables["this"];
        }

        public string RunQueryStr(String sql)
        {
            DataTable datatable = RunQuery(sql);
            if (datatable.Rows.Count > 0)
                return datatable.Rows[0][0].ToString();
            else
                return "";
        }

        public int ExecuteQuery(String sql)
        {
            try
            {
                if (IsSQLModule)
                {
                    SqlCommand com = new SqlCommand(sql, (SqlConnection)conn);
                    conn.Open();
                    return com.ExecuteNonQuery();
                }
                else
                {
                    OleDbCommand comAccess = new OleDbCommand(sql, (OleDbConnection)conn);
                    conn.Open();
                    return comAccess.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                TraceLog.Log(string.Concat(e.ToString(), " SQL:", sql), @"c:\temp\justinsql.txt");
                return 0;
            }
            finally
            {
                TraceLog.Log(sql, @"c:\temp\justinsql.txt");
            }
        }
    }
}
