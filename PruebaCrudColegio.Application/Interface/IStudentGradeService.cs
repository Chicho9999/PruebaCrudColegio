using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentGradeService
    {
        Task<IList<StudentGradeDto>> GetAllStudentGrades();
        Task<IList<StudentGradeDto>> GetAllStudentGradesByUserId(Guid userId);
        Task<bool> UpdateStudentGrades(Guid id, List<StudentGrade> grades);
    }
}
