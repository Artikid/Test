using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;
using Database.DAO;

namespace Database.DAO 
{
    public class SurveyResultsDAO : BaseDAO
    {
        public static List<SurveyResults>  GetAll (string sortString = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [SURVEYRESULTS] ");
            if(sortString!=null)
            {
                sql.Append("ORDER BY " + sortString);
            }
            List<SurveyResults>  ret = DbCon.Query<SurveyResults>(sql.ToString()).ToList();

            return ret;
        }

        public static SurveyResults GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [SURVEYRESULTS] ");
            sql.Append("WHERE [ID] = @ID ");

            return DbCon.Query<SurveyResults>(sql.ToString(), new { ID = id }).SingleOrDefault();
        }

        public static bool Insert (SurveyResults bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [SURVEYRESULTS] ");
            sql.Append("([ID], [UNIQ_ID], [USER_ID], [CREATED], [MODIFIED], [CORSO], [DATA], [DOCENTE], [ALLIEVO_NOME], [ALLIEVO_COGNOME], [ALLIEVO_EMAIL], [ALLIEVO_AZIENDA], [ALLIEVO_REPARTO], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6], [Q7], [Q8], [Q9], [Q10], [Q11], [Q12])");
            sql.Append("VALUES( @ID, @UNIQ_ID, @USER_ID, @CREATED, @MODIFIED, @CORSO, @DATA, @DOCENTE, @ALLIEVO_NOME, @ALLIEVO_COGNOME, @ALLIEVO_EMAIL, @ALLIEVO_AZIENDA, @ALLIEVO_REPARTO, @Q1, @Q2, @Q3, @Q4, @Q5, @Q6, @Q7, @Q8, @Q9, @Q10, @Q11, @Q12)");
            int rowsAffected = DbCon.Execute(sql.ToString(), bean);

            if(rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public static bool Update(SurveyResults bean)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [SURVEYRESULTS] ");
            sql.Append("SET [UNIQ_ID] =  @UNIQ_ID, [USER_ID] = @USER_ID, [CREATED] = @CREATED, [MODIFIED] = @MODIFIED, [CORSO] = @CORSO, [DATA] = @DATA, [DOCENTE] = @DOCENTE, [ALLIEVO_NOME] =  @ALLIEVO_NOME, [ALLIEVO_COGNOME] =  @ALLIEVO_COGNOME, [ALLIEVO_EMAIL] =  @ALLIEVO_EMAIL, [ALLIEVO_AZIENDA] =  @ALLIEVO_AZIENDA, [ALLIEVO_REPARTO] = @ALLIEVO_REPARTO,[Q1] = @Q1,[Q2] = @Q2,[Q3] = @Q3,[Q4] = @Q4,[Q5] = @Q5,[Q6] = @Q6,[Q7] = @Q7,[Q8] = @Q8,[Q9] = @Q9,[Q10] = @Q10,[Q11] = @Q11,[Q12] = @Q12 ");
            sql.Append("WHERE [ID] =  @ID");
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
            sql.Append("DELETE FROM [SURVEYRESULTS] ");
            sql.Append("WHERE [ID] = @ID ");

            int rowsAffected = DbCon.Execute(sql.ToString(), new { ID = id });

            if(rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
