using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IProfessorService
    {
        Task<Professor> AddProfessorAsync(ProfessorDto entity);
        Task<bool> DeleteStudentAsync(Guid id);
        Task<IList<ProfessorDto>> GetAllProfessors();
        Task<Professor?> UpdateProfessorAsync(Guid id, ProfessorDto professorDto);
    }
}
