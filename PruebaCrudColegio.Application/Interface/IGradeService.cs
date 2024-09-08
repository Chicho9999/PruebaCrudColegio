using PruebaCrudColegio.Application.Dtos;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IGradeService
    {
        Task<IList<GradeDto>> GetAllGrades();
        Task<IList<GradeDto>> GetAllGradesByUserId(Guid userId);
    }
}
