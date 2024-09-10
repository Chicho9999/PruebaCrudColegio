using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class GradeService : IGradeService
    {
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IRepository<StudentGrade> _studentGradeRepository;
        private readonly IRepository<Professor> _profressorRepository;

        public GradeService(IRepository<Grade> gradeRepository,
                            IRepository<StudentGrade> studentGradeRepository,
                            IRepository<Professor> profressorRepository)
        {
            _gradeRepository = gradeRepository;
            _studentGradeRepository = studentGradeRepository;
            _profressorRepository = profressorRepository;
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
    }
}
