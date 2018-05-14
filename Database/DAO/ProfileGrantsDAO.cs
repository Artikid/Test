using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;

namespace Database.DAO
{
    class ProfileGrantsDAO:BaseDAO
    {
        public static List<ProfileGrants> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [PROFILEGRANTS] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<ProfileGrants> ret = DbCon.Query<ProfileGrants>(sql.ToString()).ToList();

            return ret;
        }

        public static bool Insert(ProfileGrants bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [PROFILEGRANTS] ");
            sql.Append("([FUN_FK], [PRO_FK]) ");
            sql.Append("VALUES( @FUN_FK, @PRO_FK)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public static bool Delete(int funID, int proID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM [PROFILEGRANTS] ");
            sql.Append("WHERE [FUN_FK]=@FUN_FK AND [PRO_FK]=@PRO_FK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { FUN_FK = funID, PRO_FK = proID });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
