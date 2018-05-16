using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static Utils.Enumeratori;

namespace Utils
{
    public class Tools
    {
        #region Gestione delle date
        public static DateTime OnlyData(DateTime Data)
        {
            DateTime OnlyData = new DateTime(Data.Year, Data.Month, Data.Day);
            return OnlyData;
        }

        public static string GetDateStr(DateTime dataConv)
        {
            //Ottiene una stringa da un DateTime con la data formattata in base alla nostra scelta (in questo caso Italiana "dd/MM/yyyy")
            string retString = dataConv.ToString("dd/MM/yyyy");
            return retString;
        }

        public static string GetDateTimeStr(DateTime dataConv)
        {
            //Ottiene una stringa da un DateTime con la data formattata in base alla nostra scelta (in questo caso Italiana "dd/MM/yyyy")
            string retString = dataConv.ToString();
            return retString;
        }

        public static string GetDateStr(Object dataConv)
        {
            //Ottiene DateTime da un Object che viene poi passato alla funzione "GetDateStr" per ottenere una stringa
            DateTime retData = Convert.ToDateTime(dataConv);
            string retString = GetDateStr(retData);
            return retString;
        }

        public static DateTime GetDateDT(string dataConv)
        {
            //Ottiene un DateTime da una stringa con la data formattata in base alla nostra scelta (in questo caso Italiana "dd/MM/yyyy")
            DateTime DTdata = new DateTime(Convert.ToInt32(dataConv.Substring(6, 4)), Convert.ToInt32(dataConv.Substring(3, 2)), Convert.ToInt32(dataConv.Substring(0, 2)));
            return DTdata;
        }

        public static string GetClearSring(string testo)
        {
            //Sostituisce eventuali caratteri html con l'opportuna codifica.
            return HttpUtility.HtmlDecode(testo);
        }
        #endregion

        #region Max e Min su liste di dati
        public static decimal GetMinOfList(List<decimal> listValue)
        {
            decimal min = decimal.MaxValue;
            foreach (decimal value in listValue)
            {
                min = (value > 0 && value < min ? value : min);
            }
            return (min == decimal.MaxValue ? 1 : min);
        }

        public static double GetMinOfList(List<double> listValue)
        {
            double min = double.MaxValue;
            foreach (double value in listValue)
            {
                min = (value != double.NaN && value != -1 && value < min ? value : min);
            }
            return min;
        }

        public static decimal GetMinOfList(List<int> listValue)
        {
            int min = int.MaxValue;
            foreach (int value in listValue)
            {
                min = (value != -1 && value < min ? value : min);
            }
            return min;
        }

        public static decimal GetMaxOfList(List<decimal> listValue)
        {
            decimal max = decimal.MinValue;
            foreach (decimal value in listValue)
            {
                max = (value != -1 && value > max ? value : max);
            }
            return max;
        }

        public static double GetMaxOfList(List<double> listValue)
        {
            double max = 0;
            foreach (double value in listValue)
            {
                max = (value != -1 && value > max ? value : max);
            }
            return max;
        }

        public static decimal GetMaxOfList(List<int> listValue)
        {
            int max = int.MinValue;
            foreach (int value in listValue)
            {
                max = (value != -1 && value > max ? value : max);
            }
            return max;
        }
        #endregion

        #region Operazioni matematiche
        #endregion

        #region Conversione liste in stringhe concatenate
        public static string GetStringFromListForQuery(List<int> listId)
        {
            // Converte una lista di int in una stringa formattata per fare una query
            string ret = "";
            foreach (int id in listId)
            {
                ret += (ret == "" ? id.ToString() : ", " + id.ToString());
            }
            return ret;
        }

        public static string GetStringFromListForQuery(List<long> listId)
        {
            // Converte una lista di int in una stringa formattata per fare una query
            string ret = "";
            foreach (long id in listId)
            {
                ret += (ret == "" ? id.ToString() : ", " + id.ToString());
            }
            return ret;
        }

        public static string GetStringFromListForQuery(List<string> objects)
        {
            // Converte una lista di int in una stringa formattata per fare una query
            string ret = "";
            foreach (string obj in objects)
            {
                ret += (ret == "" ? obj : ", " + obj);
            }
            return ret;
        }

        public static string GetStringFromListForQuery(Dictionary<int, string> listId)
        {
            // Converte una lista di int in una stringa formattata per fare una query
            string ret = "";
            foreach (KeyValuePair<int, string> id in listId)
            {
                ret += (ret == "" ? id.Key.ToString() : ", " + id.Key.ToString());
            }
            return ret;
        }

        public static string GetStringFromListForQuery(Dictionary<long, string> listId)
        {
            // Converte una lista di int in una stringa formattata per fare una query
            string ret = "";
            foreach (KeyValuePair<long, string> id in listId)
            {
                ret += (ret == "" ? id.Key.ToString() : ", " + id.Key.ToString());
            }
            return ret;
        }
        #endregion

        #region Gestione File
        public static void DownloadFile(System.Web.HttpResponse Response, string filePath)
        {
            Byte[] file = File.ReadAllBytes(filePath);
            File.Delete(filePath);
            Response.ContentType = "documento/" + Path.GetExtension(filePath).ToUpper();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.BinaryWrite(file);
            Response.End();
        }

        public static void DownloadFile(System.Web.HttpContext context, string filePath)
        {
            Byte[] file = File.ReadAllBytes(filePath);
            File.Delete(filePath);
            context.Response.ContentType = "text/" + Path.GetExtension(filePath).ToUpper();
            context.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(filePath));
            context.Response.BinaryWrite(file);
            context.Response.End();
        }
        #endregion
    }
}
