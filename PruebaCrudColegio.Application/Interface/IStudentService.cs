using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentService
    {
        Task<Student> AddStudent(StudentDto student);
        Task<bool> DeleteStudent(Guid id);
        Task UpdateStudent(Guid id, StudentDto student);
        Task<Student?> GetStudentById(Guid id);
        Task<IList<StudentDto>> GetAllStudents();
    }
}
