using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using Dapper;

namespace Database.DAO
{
    public class UsersDAO : BaseDAO
    {
        public static List<Users> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [USERS] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<Users> ret = DbCon.Query<Users>(sql.ToString()).ToList();

            return ret;
        }

        public static Users GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [USERS] ");
            sql.Append("WHERE [USR_PK] = @USR_PK ");

            return DbCon.Query<Users>(sql.ToString(), new { USR_PK = id }).SingleOrDefault();
        }

        public static bool Insert(Users bean) {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [USERS] ");
            sql.Append("([USR_PK], [FIRSTNAME], [LASTNAME], [USERNAME], [PWD]) ");
            sql.Append("VALUES( @USR_PK, @FIRSTNAME, @LASTNAME, @USERNAME, @PWD)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public static bool Update(Users bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [USERS] ");
            sql.Append("SET [FIRSTNAME]=@FIRSTNAME, [LASTNAME]=@LASTNAME, [USERNAME]=@USERNAME, [PWD]=@PWD ");
            sql.Append("WHERE [USR_PK]=@USR_PK ");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public static bool Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM [USERS] ");
            sql.Append("WHERE [USR_PK]=@USR_PK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { USR_PK = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
