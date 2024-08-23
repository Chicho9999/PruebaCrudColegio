using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentService
    {
        Task<Student> AddStudent(StudentDto student);
        bool DeleteStudent(Guid id);
        Student? UpdateStudent(Guid id, StudentDto student);
        Student? GetStudentById(Guid id);
        Task<IList<StudentDto>> GetAllStudents();
    }
}
