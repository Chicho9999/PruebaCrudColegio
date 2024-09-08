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
            return grades.Select(x => new GradeDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task<IList<GradeDto>> GetAllGradesByUserId(Guid studentId)
        {
            var studentGrades = await _studentGradeRepository.GetWhere(grade => grade.StudentId == studentId);
            return studentGrades.Select(studentGrade =>
            {
                var grade = _gradeRepository.GetByIdAsync(studentGrade.GradeId).Result;
                var professor = _profressorRepository.GetByIdAsync(grade.ProfessorId).Result;

                return new GradeDto()
                {
                    Name = grade.Name,
                    ProfessorName = professor.FirstName + " " + professor.LastName
                };

            }).ToList();
        }
    }
}
