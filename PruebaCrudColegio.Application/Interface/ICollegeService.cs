using PruebaCrudColegio.Application.Dtos;

namespace PruebaCrudColegio.Application.Interface
{
    public interface ICollegeService
    {
        Task<IList<CollegeDto>> GetAllColleges();
    }
}
