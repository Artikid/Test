using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Users
    {
      public int USR_PK         { get; set; }
      public string FIRSTNAME   { get; set; }
      public string LASTNAME    { get; set; }
      public string USERNAME    { get; set; }
      public string PWD         { get; set; }
    }
}
