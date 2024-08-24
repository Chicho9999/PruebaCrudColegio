using PruebaCrudColegio.Application.Dtos;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IProfessorService
    {
        Task<IList<ProfessorDto>> GetAllProfessors();
    }
}
