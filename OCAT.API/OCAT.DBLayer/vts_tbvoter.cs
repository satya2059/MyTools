using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OCAT.DBLayer
{
    public class vts_tbvoter
    {
        [Key]
        public int voterid { get; set; } 
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
    }
}
