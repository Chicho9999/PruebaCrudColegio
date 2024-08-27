using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class CollegeService : ICollegeService
    {
        readonly IRepository<Grade> _collegeRepository;

        public CollegeService(IRepository<Grade> collegeRepository) {
            _collegeRepository = collegeRepository;
        }
        
        public async Task<IList<CollegeDto>> GetAllColleges()
        {
            var grades = await _collegeRepository.GetAllAsync();
            return grades.Select(x => new CollegeDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
