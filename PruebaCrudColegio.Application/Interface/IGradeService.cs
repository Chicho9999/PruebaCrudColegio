using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IGradeService
    {
        Task<Grade> AddGradeAsync(GradeDto entity);
        Task<bool> DeleteStudentAsync(Guid id);
        Task<IList<GradeDto>> GetAllGrades();
        Task<IList<GradeDto>> GetAllGradesByProfessorId(Guid userId);
        Task<Grade?> UpdateGradeAsync(Guid id, GradeDto gradeDto);
    }
}
