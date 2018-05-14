using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database.DAO
{
    public class BaseDAO
    {   //data source è il nome del server e istanza
        const string conString = "Data Source={serverName};Initial Catalog=CORSO2018;Persist Security Info=False;Password=password;User ID=sa;";
        private static SqlConnection dbCon = new SqlConnection(conString);
        protected static SqlConnection DbCon { get => dbCon; set => dbCon = value; }
        
        public static void OpenConnection (string connectionString = null)
        {
            if(connectionString!=null)
                dbCon.ConnectionString = connectionString;
            if (dbCon.State == System.Data.ConnectionState.Closed)
                dbCon.Open();
        }

        public static void CloseConnection (string connectionString = null)
        {
            if (dbCon.State != System.Data.ConnectionState.Closed)
                dbCon.Close();
        }
      
    }
}
