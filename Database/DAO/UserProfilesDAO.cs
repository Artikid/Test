using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Database.Models;

namespace Database.DAO
{
    public class UserProfilesDAO : BaseDAO
    {
        public static List<UserProfiles> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [USERPROFILES] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<UserProfiles> ret = DbCon.Query<UserProfiles>(sql.ToString()).ToList();

            return ret;
        }

        public static bool Insert(UserProfiles bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [USERPROFILES] ");
            sql.Append("([USER_FK], [PRO_FK])");
            sql.Append("VALUES( @USER_FK, @PRO_FK)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        

        public static bool Delete(int usrID, int proID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM [USERPROFILES] ");
            sql.Append("WHERE [USER_FK] = @USER_FK AND [PRO_FK]=@PRO_FK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { USER_FK = usrID, PRO_FK  = proID });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
        public static List<UserProfiles> GetAllUsersForProfile(int idProfile)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [V_USER_PROFILES] WHERE [PRO_FK]=@ID ");
            List<UserProfiles> ret = DbCon.Query<UserProfiles>(sql.ToString(), new { ID = idProfile }).ToList();
            return ret;

        }
        public static List<UserProfiles> GetProfileForUser(int idUser)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [V_USERS_PROFILES] WHERE [USR_FK]=@ID ");
            return DbCon.Query<UserProfiles>(sql.ToString(), new { ID = idUser }).ToList();

        }
    }
}
