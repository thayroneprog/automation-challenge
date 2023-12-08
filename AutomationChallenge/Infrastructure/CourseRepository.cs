using Domain.Entities;
using Domain.Interfaces.Repositor;

namespace AutomationChallenge.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AutomationChallengeDbContext _context;

        public CourseRepository(AutomationChallengeDbContext context)
        {
            _context = context;
        }

        public void InsertCourse(CourseInformationEntity course)
        {
            course.Id = course.Id == Guid.Empty ? Guid.NewGuid() : course.Id;

            _context.Add(course);
            _context.SaveChanges();
        }
    }
}
