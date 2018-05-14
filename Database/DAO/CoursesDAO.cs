using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Database.Models;

namespace Database.DAO
{
    class CoursesDAO:BaseDAO
    {
        public static List<Courses> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [COURSES] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<Courses> ret = DbCon.Query<Courses>(sql.ToString()).ToList();

            return ret;
        }

        public static Courses GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [COURSES] ");
            sql.Append("WHERE [COU_PK] = @COU_PK ");

            return DbCon.Query<Courses>(sql.ToString(), new { COU_PK = id }).SingleOrDefault();
        }

        public static bool Insert(Courses bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [COURSES] ");
            sql.Append("([COU_PK], [TITLE], [PERIOD] ");
            sql.Append("VALUES( @COU_PK, @TITLE, @PERIOD)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public static bool Update(Courses bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [COURSES] ");
            sql.Append("SET [TITLE]=@TITLE, [PERIOD]=@PERIOD ");
            sql.Append("WHERE [COU_PK]=@COU_PK ");
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
            sql.Append("DELETE FROM [COURSES] ");
            sql.Append("WHERE [COU_PK]=@COU_PK ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { COU_PK = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
