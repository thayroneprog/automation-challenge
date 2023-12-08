using Domain.Entities;
using Domain.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AutomationChallenge.Infrastructure
{
    public class AutomationChallengeDbContext : DbContext
    {
        public DbSet<CourseInformationEntity> CourseInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=automationchallengedb;Username=admin;Password=admin;");
        }
    }
}
