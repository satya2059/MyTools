using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OCAT.DBLayer
{
    public class vts_tbvoterdetail
    {
        public int voterid { get; set; }
        public string firstname { get; set; }
        public string middle { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int customerid { get; set; }
        public string ssn { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

        [Key]
        public int voterdetailid { get; set; }
        
    }
}
