using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Hosting;
using System.Threading;
using System.Xml;
using System.Reflection;
using System.Data.Common;
using log4net;
using System.Diagnostics;

namespace Utils
{
    public class ResourceFactory
    {
        private ResourceFactory()
        {
        }

        public static SqlConnection GetConnection()
        {            
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(GetConnectionString());
                cn.Open();
            }
            catch (Exception ex)
            {
                throw new CustomException("Eccezione SQL durante la creazione di una connessione", ex);
            }

            return cn;
        }

        public static string GetConnectionString()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCorsi"].ConnectionString;
            return connection;
        }

        public static string ApplicationPath
        {
            get
            {
                return HostingEnvironment.ApplicationPhysicalPath.ToString();
            }
        }

        public static ILog GetFileLogger()
        {
            return LogManager.GetLogger("FileLog");
        }

        public static string GetAppSetting(string key)
        {
            string ret = ConfigurationManager.AppSettings[key];
            return ret;
        }
    }
}
