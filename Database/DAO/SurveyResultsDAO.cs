using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Dapper;
using Database.DAO;
using Utils;

namespace Database.DAO
{
    public class SurveyResultsDAO : BaseDAO
    {

        public static List<SurveyResults> GetAll(int id)
        {
            List<SurveyResults> ret;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM SURVEYRESULTS ");
            sql.Append("INNER JOIN COURSERESULTS ON SURVEYRESULTS.ID=COURSERESULTS.RES_FK ");
            sql.Append("WHERE COU_FK=@COU_FK ");

            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    ret = cn.Query<SurveyResults>(sql.ToString(), new { COU_FK = id }).ToList();
                }
            }
            catch (Exception e)
            {

                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("COU_FK", id);
                throw new CustomException(eh.ToString(), e);
            }

            return ret;
        }
        public static List<SurveyResults> GetAll(string nomeCorso = null)
        {
            List<SurveyResults> ret;
            StringBuilder sql = new StringBuilder("SELECT * FROM [SURVEYRESULTS] ");
            if (!nomeCorso.Equals(""))
            {
                sql.Append("WHERE UPPER(CORSO) LIKE CONCAT('%', @CORSO, '%') ");
            }

            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    ret = cn.Query<SurveyResults>(sql.ToString(), new { CORSO = nomeCorso }).ToList();
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("nomeCorso", nomeCorso);
                throw new CustomException(eh.ToString(), e);
            }

            return ret;
        }

        public static SurveyResults GetSingle(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM [SURVEYRESULTS] ");
            sql.Append("WHERE [ID] = @ID ");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    return cn.Query<SurveyResults>(sql.ToString(), new { ID = id }).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("ID", id);
                throw new CustomException(eh.ToString(), e);
            }
        }

        public static Int32 Insert(SurveyResults bean)
        {
            int ret;
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO [SURVEYRESULTS] ");
            sql.Append("([UNIQ_ID], [USER_ID], [CREATED], [MODIFIED], [CORSO], [DATA], [DOCENTE], [ALLIEVO_NOME], [ALLIEVO_COGNOME], [ALLIEVO_EMAIL], [ALLIEVO_AZIENDA], [ALLIEVO_REPARTO], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6], [Q7], [Q8], [Q9], [Q10], [Q11], [Q12])   ");
            sql.Append("VALUES(@UNIQ_ID, @USER_ID, @CREATED, @MODIFIED, @CORSO, @DATA, @DOCENTE, @ALLIEVO_NOME, @ALLIEVO_COGNOME, @ALLIEVO_EMAIL, @ALLIEVO_AZIENDA, @ALLIEVO_REPARTO, @Q1, @Q2, @Q3, @Q4, @Q5, @Q6, @Q7, @Q8, @Q9, @Q10, @Q11, @Q12); SELECT CAST(scope_identity() AS int)");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    ret = cn.Query<Int32>(sql.ToString(), bean).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("ID", bean);
                throw new CustomException(eh.ToString(), e);
            }

            return ret;

        }
        public static bool Update(SurveyResults bean)
        {
            int rowsAffected;
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [SURVEYRESULTS] ");
            sql.Append("SET [UNIQ_ID] =  @UNIQ_ID, [USER_ID] = @USER_ID, [CREATED] = @CREATED, [MODIFIED] = @MODIFIED, [CORSO] = @CORSO, [DATA] = @DATA, [DOCENTE] = @DOCENTE, [ALLIEVO_NOME] =  @ALLIEVO_NOME, [ALLIEVO_COGNOME] =  @ALLIEVO_COGNOME, [ALLIEVO_EMAIL] =  @ALLIEVO_EMAIL, [ALLIEVO_AZIENDA] =  @ALLIEVO_AZIENDA, [ALLIEVO_REPARTO] = @ALLIEVO_REPARTO,[Q1] = @Q1,[Q2] = @Q2,[Q3] = @Q3,[Q4] = @Q4,[Q5] = @Q5,[Q6] = @Q6,[Q7] = @Q7,[Q8] = @Q8,[Q9] = @Q9,[Q10] = @Q10,[Q11] = @Q11,[Q12] = @Q12 ");
            sql.Append("WHERE [ID] =  @ID");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    rowsAffected = cn.Execute(sql.ToString(), bean);
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("ID", bean);
                throw new CustomException(eh.ToString(), e);
            }

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public static bool Delete(int id)
        {
            int rowsAffected;
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM [SURVEYRESULTS] ");
            sql.Append("WHERE [ID] = @ID ");
            try
            {
                using (SqlConnection cn = ResourceFactory.GetConnection())
                {
                    rowsAffected = cn.Execute(sql.ToString(), new { ID = id });
                }
            }
            catch (Exception e)
            {
                ExceptionExtras eh = new ExceptionExtras("Errore durante la lettura dei SurveyResults");
                eh.AddParam("sql", sql);
                eh.AddParam("ID", id);
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
