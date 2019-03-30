using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OCAT.DBLayer
{
    public class vts_tbuser
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }

        public string creationdate {get;set;}

        public string lastlogin {get;set;}

        public string passwordsalt {get;set;}
    }
}
