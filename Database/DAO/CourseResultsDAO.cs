using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;

namespace Database.DAO
{
    public class CourseResultsDAO:BaseDAO
    {
        public static List<CourseResults> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [COURSERESULTS] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<CourseResults> ret = DbCon.Query<CourseResults>(sql.ToString()).ToList();

            return ret;
        }

        //public static Users GetSingle(int id)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("SELECT * ");
        //    sql.Append("FROM [COURSERESULTS] ");
        //    sql.Append("WHERE [ID] = @ID ");

        //    return DbCon.Query<Users>(sql.ToString(), new { ID = id }).SingleOrDefault();
        //}

        public static bool Insert(CourseResults bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [COURSERESULTS] ");
            sql.Append("([COU_FK], [RES_FK]) ");
            sql.Append("VALUES( @COU_FK, @RES_FK)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        //public static bool Update(int id)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("UPDATE [USERS] ");
        //    sql.Append("SET [FIRSTNAME]=@FIRSTNAME, [LASTNAME]=@LASTNAME, [USERNAME]=@USERNAME, [PWD]=@PWD ");
        //    sql.Append("WHERE [USR_PK]=@USR_PK ");
        //    int rowsAffected = DbCon.Execute(sql.ToString(), id);

        //    if (rowsAffected > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public static bool Delete(int couID, int resID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM [COURSERESULTS] ");
            sql.Append("WHERE [COU_FK]=@COU_FK AND [RES_FK]=@RES_FK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { COU_FK= couID, RES_FK= resID });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
