using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;
using System.Data.SqlClient;
using Utils;

namespace Database.DAO
{
    public class CourseResultsDAO : BaseDAO
    {
        public static List<CourseResults> GetAll(string sortString = null)
        {
            List<CourseResults> ret;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [COURSERESULTS] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    ret = cn.Query<CourseResults>(sql.ToString()).ToList();
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei CourseResults");
                eh.AddParam("sql", sql);
                throw new CustomException(eh.ToString(), e);
            }
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
            int rowsAffected;
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [COURSERESULTS] ");
            sql.Append("([COU_FK], [RES_FK]) ");
            sql.Append("VALUES( @COU_FK, @RES_FK)");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    rowsAffected = cn.Execute(sql.ToString(), bean);
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei CourseResults");
                eh.AddParam("sql", sql);
                eh.AddParam("bean", bean);
                throw new CustomException(eh.ToString(), e);
            }

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

        public static bool Delete(int couID)
        {
            int rowsAffected;
            StringBuilder sql = new StringBuilder("DELETE FROM [COURSERESULTS] WHERE [COU_FK]=@COU_FK ");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    rowsAffected = cn.Execute(sql.ToString(), new { COU_FK = couID });
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei CourseResults");
                eh.AddParam("sql", sql);
                eh.AddParam("COU_FK", couID);
                throw new CustomException(eh.ToString(), e);
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
