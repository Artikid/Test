using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.DAO;
using System.Configuration;
using Database.Models;
using System.Data.SqlClient;

namespace TestDatabase
{
    class Program
 
        {
            static void Main(string[] args)
            {
            TestUserProfile();
            }

        static void DisplaySurveyResults(SurveyResults s)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("  ID               = {0}", s.ID);
            Console.WriteLine("  DOCENTE          = {0}", s.DOCENTE);
            Console.WriteLine("  DATA             = {0}", s.DATA);
            Console.WriteLine("  CORSO            = {0}", s.CORSO);
            Console.WriteLine("  ALLIEVO_COGNOME  = {0}", s.ALLIEVO_COGNOME);
            Console.WriteLine("  ALLIEVO_NOME     = {0}", s.ALLIEVO_NOME);
            Console.WriteLine("  ALLIEVO_AZIENDA  = {0}", s.ALLIEVO_AZIENDA);
            Console.WriteLine("  ALLIEVO_EMAIL    = {0}", s.ALLIEVO_EMAIL);
            Console.WriteLine("  Note sul corso   = {0}", s.Q11);
            Console.WriteLine("==========================================");
        }

        static void DisplayUserProfile(UserProfiles s)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("  ID                  = {0}", s.USER_FK);
            Console.WriteLine("  NOME                = {0}", s.FIRSTNAME);
            Console.WriteLine("  COGNOME             = {0}", s.LASTNAME);
            Console.WriteLine("  USERNAME            = {0}", s.USERNAME);
            Console.WriteLine("  PASSWORD            = {0}", s.PWD);
            Console.WriteLine("  PROFILO             = {0}", s.PRO_NAME);
            Console.WriteLine("==========================================");
        }

        private static void TestUserProfile()
        {
        //    string conString = ConfigurationManager.ConnectionStrings["DBCorsi"].ConnectionString;
        //    UserProfilesDAO.OpenConnection(conString);
        //    Console.WriteLine("\n\n** Test metodo USERPROFILES \n");
        //    List<UserProfiles> sr = UserProfilesDAO.GetAllUsersForProfile(1);
        //    foreach (UserProfiles tmp in sr)
        //        DisplayUserProfile(tmp);
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();

        //}
        //private static void TestSurveyResult()
        //{
        //    string conString = ConfigurationManager.ConnectionStrings["DBCorsi"].ConnectionString; 
        //    SurveyResultsDAO.OpenConnection(conString);
        //    Console.WriteLine("\n\n** Test metodo GETALL \n");
        //    List<SurveyResults> sr = SurveyResultsDAO.GetAll();
        //    foreach (SurveyResults tmp in sr)
        //        DisplaySurveyResults(tmp);
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();

        //    Console.Clear();
        //    Console.WriteLine("\n\n** Test metodo GETSINGLE \n");
        //    SurveyResults s = SurveyResultsDAO.GetSingle(23);
        //    DisplaySurveyResults(s);
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();

        //    Console.WriteLine("\n\n** Test metodo UPDATE \n");

        //    s.Q11 = "Nota inserita come test.....";
        //    if (SurveyResultsDAO.Update(s))
        //    {
        //        Console.WriteLine("\n Aggiornamento avvenuta con successo!");
        //        DisplaySurveyResults(s);
        //    }
        //    else
        //        Console.WriteLine("Nessun aggiornamento è stato effettuato.\n");
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();


        //    Console.WriteLine("\n\n** Test metodo DELETE \n");
        //    if (SurveyResultsDAO.Delete(s.ID))
        //        Console.WriteLine("\n Cancellazione dell' ID = 24 avvenuta con successo!");
        //    else
        //        Console.WriteLine("Nessuna cancellazione è stata effettuata.\n");
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();

        //    Console.WriteLine("\n\n** Test metodo INSERT \n");
        //    if (SurveyResultsDAO.Insert(s))
        //    {
        //        Console.WriteLine("\n Inserimento avvenuto con successo!");
        //        DisplaySurveyResults(s);
        //    }
        //    else
        //        Console.WriteLine("Nessun inserimento è stato effettuato.\n");
        //    Console.WriteLine("*****************************************************");
        //    Console.WriteLine("Premi un tasto per continuare...");
        //    Console.ReadKey();
        }
    }
}

