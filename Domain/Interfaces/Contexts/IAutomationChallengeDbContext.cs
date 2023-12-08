using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Contexts
{
    public interface IAutomationChallengeDbContext
    {
        DbSet<CourseInformationEntity> Courses { get; set; }
        Task<int> SaveChangesAsync();
    }
}
