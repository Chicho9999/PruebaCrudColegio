using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class CollegeService : ICollegeService
    {
        readonly IRepository<College> _collegeRepository;

        public CollegeService(IRepository<College> collegeRepository) {
            _collegeRepository = collegeRepository;
        }
        
        public async Task<IList<CollegeDto>> GetAllColleges()
        {
            var colleges = await _collegeRepository.GetAllAsync();
            return colleges.Select(x => new CollegeDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
