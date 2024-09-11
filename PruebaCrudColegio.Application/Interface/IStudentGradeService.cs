using PruebaCrudColegio.Application.Dtos;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentGradeService
    {
        Task<IList<StudentGradeDto>> GetAllStudentGradesAsync();
        Task<IList<StudentGradeDto>> GetAllStudentGradesByUserIdAsync(Guid userId);
        Task<bool> UpdateStudentGradesAsync(Guid id, List<StudentGradeDto> grades);
    }
}
