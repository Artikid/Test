using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Database.Models;

namespace Database.DAO
{
    class ParametersDAO:BaseDAO
    {
        public static List<Parameters> GetAll(string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [PARAMETERS] ");
            if (sortString != null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<Parameters> ret = DbCon.Query<Parameters>(sql.ToString()).ToList();

            return ret;
        }

        public static Parameters GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [PARAMETERS] ");
            sql.Append("WHERE [ID] = @ID ");

            return DbCon.Query<Parameters>(sql.ToString(), new { ID = id }).SingleOrDefault();
        }

        public static bool Insert(Parameters bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [PARAMETERS] ");
            sql.Append("([ID], [PARAMNAME], [PARAMTYPE], [NUMVAL], [DATEVAL], [BOOLVAL], [DESCRIPTION], [TEXTVAL], [EDITABLE]) ");
            sql.Append("VALUES( @ID, @PARAMNAME, @PARAMTYPE, @NUMVAL, @DATEVAL, @BOOLVAL, @DESCRIPTION, @TEXTVAL, @EDITABLE)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public static bool Update(Parameters bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [PARAMETERS] ");
            sql.Append("SET [PARAMNAME]=@PARAMNAME, [PARAMTYPE]=@PARAMTYPE, [NUMVAL]=@NUMVAL, [DATEVAL]=@DATEVAL, [BOOLVAL]=@BOOLVAL, [DESCRIPTION]=@DESCRIPTION, [TEXTVAL]=@TEXTVAL, [EDITABLE]=@EDITABLE ");
            sql.Append("WHERE [ID]=@ID ");
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
            sql.Append("DELETE FROM [PARAMETERS] ");
            sql.Append("WHERE [ID]=@ID ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { ID = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
