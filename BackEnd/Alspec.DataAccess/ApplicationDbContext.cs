using Alspec.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alspec.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(new Job

            {
                Id = "1",
                Title = "Job 1",
                Description = "Aslpec 1"
            }
            );
            modelBuilder.Entity<SubItem>().HasData(new SubItem

            {
                ItemId = "1",
                Title = "Sub-Item 1",
                Description = "Sub-Item 1  Description",
                Status="Pending",
                JobId="1",
            }, new SubItem

            {
                ItemId = "2",
                Title = "Sub-Item 2",
                Description = "Sub-Item 2 Description",
                Status = "In Progress",
                JobId = "1",
            }
            );
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SubItem> SubItems { get; set; }

    }
}
