using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OCAT.DBLayer
{
   public class DataModel
    {
        public string firstname { get; set; }
        public string middle { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int customerid { get; set; }
        public string ssn { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

        [Required]
        public string uid { get; set; }
        public int surveyid { get; set; }
        public string contextusername { get; set; }
        public string votedate { get; set; }
        public string startdate { get; set; }
        public string ipsource { get; set; }
        public bool validated { get; set; }
        public string resumeuid { get; set; }
        public int resumeatpagenumber { get; set; }
        public string progresssavedate { get; set; }
        public int resumequestionnumber { get; set; }
        public int resumehighestpagenumber { get; set; }
        public string languagecode { get; set; }

        public string graduate { get; set; }
        public string graduateyear { get; set; }
        public string postgraduate { get; set; }
        public string pgyear { get; set; }
        public string highdegree { get; set; }
        public string other { get; set; }

        public int sectionnumber { get; set; }
        public bool noshow { get; set; }
        public string answertext { get; set; }
    }
}
