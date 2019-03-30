using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCAT.DBLayer
{
    public class OCAT :  DbContext, IDisposable
    {
        public OCAT()
            : base("name=OCAT")
        {
            Database.SetInitializer<OCAT>(null);
        }

        public DbSet<vts_tbuser> Users { get; set; }       
        public DbSet<vts_tbvoter> Voters { get; set; }
        public DbSet<vts_tbvoteranswers> VoterAnswers { get; set; }
        public DbSet<vts_tbvoterdetail> VoterDetails { get; set; }
        public DbSet<vts_tbvotereducation> VoterEducation { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //builder.HasDefaultSchema(this.schema);
           // base.OnModelCreating(builder);
            builder.Entity<vts_tbuser>().ToTable("vts_tbuser", "public");
            builder.Entity<vts_tbvoter>().ToTable("vts_tbvoter", "public");
            builder.Entity<vts_tbvoteranswers>().ToTable("vts_tbvoteranswers", "public");
            builder.Entity<vts_tbvoterdetail>().ToTable("vts_tbvoterdetail", "public");
            builder.Entity<vts_tbvotereducation>().ToTable("vts_tbvotereducation", "public");
        }
    }
}
