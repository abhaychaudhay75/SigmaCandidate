using JobCandidate.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data
{
    public class SigmaCandidateDBContext : DbContext
    {
        public SigmaCandidateDBContext(DbContextOptions<SigmaCandidateDBContext> options) : base(options)
        {
        }
            public DbSet<CandidateModel> Candidate { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateModel>().ToTable("Candidates"); // Pluralized table name

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CandidateModel>()
        .HasKey(c => c.Id);
        }

    }
    
}
