using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class ProfessorService : IProfessorService
    {
        private readonly IRepository<Professor> _professorRepository;
        private readonly IRepository<Grade> _gradeRepository;

        public ProfessorService(IRepository<Professor> professorRepository, IRepository<Grade> gradeRepository) {
            _professorRepository = professorRepository;
            _gradeRepository = gradeRepository;
        }

        public async Task<Professor> AddProfessorAsync(ProfessorDto entity)
        {
            Professor professor = MapProfessor(entity);

            await _professorRepository.AddAsync(professor);

            return professor;
        }

        public async Task<IList<ProfessorDto>> GetAllProfessors()
        {
            var professors = await _professorRepository.GetAllAsync();
            return professors.Select(x => new ProfessorDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender
            }).ToList();
        }

        public async Task<Professor?> UpdateProfessorAsync(Guid id, ProfessorDto professorDto)
        {
            var professor = MapProfessor(professorDto);

            var profeToEdit = await _professorRepository.GetByIdAsync(id);
            if (profeToEdit != null)
            {
                profeToEdit.FirstName = professor.FirstName;
                profeToEdit.LastName = professor.LastName;
                profeToEdit.Gender = professor.Gender;

                await _professorRepository.UpdateAsync(profeToEdit);

                return profeToEdit;
            }

            return null;
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var professorToDelete = await _professorRepository.GetByIdAsync(id);

            var grades = await _gradeRepository.GetWhere(sg => sg.ProfessorId == id);

            var gradesDeleted = await _gradeRepository.BulkDeleteAsync([.. grades]);

            if (professorToDelete != null && gradesDeleted)
            {
                await _professorRepository.DeleteAsync(professorToDelete);
                return true;
            }
            return false;
        }

        private Professor MapProfessor(ProfessorDto entity)
        {
            return new Professor()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName, 
                Gender = entity.Gender
            };
        }
    }
}
