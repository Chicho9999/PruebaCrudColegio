using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IGradeService
    {
        Task<IList<GradeDto>> GetAllGrades();
        Task<IList<GradeDto>> GetAllGradesByProfessorId(Guid userId);
    }
}
