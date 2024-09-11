using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(StudentDto student);
        Task<bool> DeleteStudent(Guid id);
        Task<Student?> UpdateStudentAsync(Guid id, StudentDto student);
        Task<Student?> GetStudentByIdAsync(Guid id);
        Task<IList<StudentDto>> GetAllStudents();
    }
}
