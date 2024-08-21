using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.Application.Interface
{
    public interface IStudentService
    {
        Task<Student> AddStudent(Student student);
        Task<bool> DeleteStudent(Guid id);
        Task UpdateStudent(Guid id, Student student);
        Task<Student?> GetStudentById(Guid id);
        Task<IList<Student>> GetAllStudents();
    }
}
