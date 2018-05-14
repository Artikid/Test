using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Parameters
    {
        public int ID              { get; set; }
        public string PARAMNAME    { get; set; }
        public string PARAMTYPE    { get; set; }
        public decimal? NUMVAL     { get; set; }
        public DateTime? DATEVAL   { get; set; }
        public string BOOLVAL      { get; set; }
        public string DESCRIPTION  { get; set; }
        public string TEXTVAL      { get; set; }
        public string EDITABLE     { get; set; }
    }
}
