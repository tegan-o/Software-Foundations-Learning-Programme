using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts{

    public class ApplicantInfoContext : DbContext{

        public DbSet<Applicant> Applicants { get; set; }

        public ApplicantInfoContext(DbContextOptions<ApplicantInfoContext> options): base(options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
            

            base.OnModelCreating(modelBuilder);
        }


    }
}