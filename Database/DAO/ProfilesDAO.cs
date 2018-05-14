using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;

namespace Database.DAO
{
    class ProfilesDAO:BaseDAO
    {
        public static List<Profiles> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [PROFILES] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<Profiles> ret = DbCon.Query<Profiles>(sql.ToString()).ToList();

            return ret;
        }

        public static Profiles GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [PROFILES] ");
            sql.Append("WHERE [PRO_PK] = @PRO_PK ");

            return DbCon.Query<Profiles>(sql.ToString(), new { PRO_PK = id }).SingleOrDefault();
        }

        public static bool Insert(Profiles bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [PROFILES] ");
            sql.Append("([PRO_PK], [PRO_NAME])");
            sql.Append("VALUES( @PRO_PK, @PRO_NAME)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public static bool Update(Profiles bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [PROFILES] ");
            sql.Append("SET [PRO_NAME] =  @PRO_NAME");
            sql.Append("WHERE [PRO_PK] =  @PRO_PK");
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
            sql.Append("DELETE FROM [PROFILES] ");
            sql.Append("WHERE [PRO_PK] = @PRO_PK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { PRO_PK = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
