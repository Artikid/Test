using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class UserProfiles
    {
        public int USER_FK { get; set; }
        public int PRO_FK  { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string USERNAME { get; set; }
        public string PWD { get; set; }
        public string PRO_NAME { get; set; }

    }
}
