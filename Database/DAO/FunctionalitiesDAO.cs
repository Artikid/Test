using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;

namespace Database.DAO
{
    class FunctionalitiesDAO: BaseDAO
    {
        public static List<Functionalities> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [FUNCTIONALITIES] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<Functionalities> ret = DbCon.Query<Functionalities>(sql.ToString()).ToList();

            return ret;
        }

        public static Functionalities GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [FUNCTIONALITIES] ");
            sql.Append("WHERE [FUN_PK] = @FUN_PK ");

            return DbCon.Query<Functionalities>(sql.ToString(), new { FUN_PK = id }).SingleOrDefault();
        }

        public static bool Insert(Functionalities bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [FUNCTIONALITIES] ");
            sql.Append("([FUN_PK], [FUN_NAME]) ");
            sql.Append("VALUES( @FUN_PK, @FUN_NAME)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public static bool Update(Functionalities bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [FUNCTIONALITIES] ");
            sql.Append("SET [FUN_NAME]=@FUN_NAME ");
            sql.Append("WHERE [FUN_PK]=@FUN_PK ");
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
            sql.Append("DELETE FROM [FUNCTIONALITIES] ");
            sql.Append("WHERE [FUN_PK]=@FUN_PK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { FUN_PK = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
