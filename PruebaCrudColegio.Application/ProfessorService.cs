using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class ProfessorService : IProfessorService
    {
        readonly IRepository<Professor> _professorRepository;

        public ProfessorService(IRepository<Professor> professorRepository) {
            _professorRepository = professorRepository;
        }
        
        public async Task<IList<ProfessorDto>> GetAllProfessors()
        {
            var professors = await _professorRepository.GetAllAsync();
            return professors.Select(x => new ProfessorDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();
        }
    }
}
