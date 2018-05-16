using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    [ToString]
    public class SurveyResults
    {
      public  int   ID                      { get; set; } 
      public string UNIQ_ID                 { get; set; } 
      public int     USER_ID                { get; set; } 
      public DateTime CREATED               { get; set; } 
      public DateTime? MODIFIED              { get; set; } 
      public string CORSO                   { get; set; } 
      public string DATA                    { get; set; } 
      public string DOCENTE                 { get; set; } 
      public string ALLIEVO_NOME            { get; set; } 
      public string ALLIEVO_COGNOME         { get; set; } 
      public string ALLIEVO_EMAIL           { get; set; } 
      public string ALLIEVO_AZIENDA         { get; set; } 
      public string ALLIEVO_REPARTO         { get; set; } 
      public string Q1                      { get; set; } 
      public string Q2                      { get; set; } 
      public string Q3                      { get; set; } 
      public string Q4                      { get; set; } 
      public string Q5                      { get; set; } 
      public string Q6                      { get; set; } 
      public string Q7                      { get; set; } 
      public string Q8                      { get; set; } 
      public string Q9                      { get; set; } 
      public string Q10                     { get; set; } 
      public string Q11                     { get; set; } 
      public string Q12                     { get; set; }
    }
}
