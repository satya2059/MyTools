using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OCAT.DBLayer
{
    public class vts_tbvoteranswers
    {
        public int voterid { get; set; }

        [Key]
        public int answerid { get; set; }

        public int sectionnumber { get; set; }
        public bool noshow { get; set; }
        public string answertext { get; set; }
    }
}
