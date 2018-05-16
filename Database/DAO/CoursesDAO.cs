using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Database.Models;

namespace Database.DAO
{
    public class CoursesDAO:BaseDAO
    {
        public static List<Courses> GetAll(string title = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [COURSES] ");
            if (title.Equals(""))
            {
                sql.Append("WHERE UPPER(TITLE) LIKE UPPER(CONCAT('%',@TITLE,'%'))");
            }
            List<Courses> ret = DbCon.Query<Courses>(sql.ToString(), new { TITLE=title }).ToList();

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

        public static Int32 Insert(Courses bean)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [COURSES] ");
            sql.Append("([TITLE], [PERIOD]) ");
            sql.Append("VALUES(@TITLE, @PERIOD); SELECT CAST(scope_identity() AS int)");
            int ret = DbCon.Query<Int32>(sql.ToString(), bean).FirstOrDefault();
  
                return ret; 
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
