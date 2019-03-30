using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OCAT.DBLayer
{
    public class vts_tbvotereducation
    {
        public int voterid { get; set; }
        [Key]
        public int educationid { get; set; }
        public string graduate { get; set; }
        public string graduateyear { get; set; }
        public string postgraduate { get; set; }
        public string pgyear { get; set; }
        public string highdegree { get; set; }
        public string other { get; set; }
    }
}
