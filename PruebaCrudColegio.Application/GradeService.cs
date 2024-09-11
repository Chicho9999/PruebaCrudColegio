using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class GradeService : IGradeService
    {
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IRepository<Professor> _profressorRepository;

        public GradeService(IRepository<Grade> gradeRepository,
                            IRepository<Professor> profressorRepository)
        {
            _gradeRepository = gradeRepository;
            _profressorRepository = profressorRepository;
        }

        public async Task<Grade> AddGradeAsync(GradeDto entity)
        {
            Grade grade = MapGrade(entity);

            await _gradeRepository.AddAsync(grade);

            return grade;
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var studentToDelete = await _gradeRepository.GetByIdAsync(id);

            if (studentToDelete != null)
            {
                await _gradeRepository.DeleteAsync(studentToDelete);
                return true;
            }
            return false;
        }

        public async Task<IList<GradeDto>> GetAllGrades()
        {
            var grades = await _gradeRepository.GetAllAsync();
            return grades.Select(grade =>
            {
                var professor = _profressorRepository.GetByIdAsync(grade.ProfessorId).Result;
                return new GradeDto()
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    ProfessorId = professor.Id,
                    ProfessorName = professor.FirstName + " " + professor.LastName
                };

            }).ToList();
        }

        public async Task<IList<GradeDto>> GetAllGradesByProfessorId(Guid professorId)
        {
            var grades = await _gradeRepository.GetWhere(grade => grade.ProfessorId == professorId);
            return grades.Select(grade =>
            {
                var professor = _profressorRepository.GetByIdAsync(grade.ProfessorId).Result;

                return new GradeDto()
                {
                    Id = grade.Id,
                    Name = grade.Name,
                    ProfessorName = professor.FirstName + " " + professor.LastName
                };

            }).ToList();
        }

        public async Task<Grade?> UpdateGradeAsync(Guid id, GradeDto gradeDto)
        {
            var grade = MapGrade(gradeDto);

            var gradeToEdit = await _gradeRepository.GetByIdAsync(id);
            if (gradeToEdit != null)
            {
                gradeToEdit.Name = grade.Name;
                gradeToEdit.ProfessorId = grade.ProfessorId;

                await _gradeRepository.UpdateAsync(gradeToEdit);

                return gradeToEdit;
            }

            return null;
        }

        private Grade MapGrade(GradeDto entity)
        {
            return new Grade()
            {
                Id = entity.Id,
                Name = entity.Name,
                ProfessorId = entity.ProfessorId
            };
        }
    }
}
