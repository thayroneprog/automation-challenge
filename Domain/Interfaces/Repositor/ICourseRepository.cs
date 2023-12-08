using Domain.Entities;

namespace Domain.Interfaces.Repositor
{
    public interface ICourseRepository
    {
        public void InsertCourse(CourseInformationEntity course);
    }
}
