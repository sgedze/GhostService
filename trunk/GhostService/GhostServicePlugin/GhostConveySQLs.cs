using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService.GhostServicePlugin
{
    /// <summary>
    /// A collection of GC SQLs we use with the application version it
    /// will work on
    /// </summary>
    public static class GhostConveySQLs
    {
        public static void GC_USR_punters_GetNotifyUserListSQL(out string sql, out Version fromVersion)
        {
            sql = "SELECT DISTINCT LogonName from USR_Punters WHERE ReceiveUpdateNotification <> 0";
            fromVersion = new Version("10.2.0.0");
        }

        public static void GC_USR_firm_GetLicenseSQL(out string sql)
        {
            sql = "SELECT DISTINCT LicensingCode from USR_firm";
        }

        public static void GC_USR_UserMessages_InsertMsgSQL(out string sql, out Version fromVersion)
        {
            sql = "INSERT INTO USR_UserMessages (UserMsgId,DateActivate,LogonName,UserMessage, MessageFrom) VALUES ('{0}','{1}','{2}','{3}','{4}')";
            fromVersion = new Version("10.2.0.0");
        }

        public static void GC_USR_UserMessages_InsertMsgSQL(out string sql, out Version fromVersion, string userMsgId, string dateActivate, string logonName, string userMessage, string messageFrom)
        {
            GC_USR_UserMessages_InsertMsgSQL(out sql, out fromVersion);
            sql = string.Format(sql, userMsgId, dateActivate, logonName, userMessage, messageFrom);
        }
    }
}
