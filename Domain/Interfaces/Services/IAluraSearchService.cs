using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IAluraSearchService
    {
        public List<CourseInformationEntity> RealizarBusca(string termo);
    }
}
