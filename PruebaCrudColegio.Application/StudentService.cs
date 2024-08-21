using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class StudentService : IStudentService
    {
        readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository) {
            _studentRepository = studentRepository;
        }
        
        public async Task<Student> AddStudent(Student student)
        {
            await _studentRepository.AddAsync(student);

            return student;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(id);
            if (studentToDelete != null) { 
                await _studentRepository.DeleteAsync(studentToDelete);
                return true;
            }
            return false;
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateStudent(Guid id, Student student)
        {
            var studentToEdit = await _studentRepository.GetByIdAsync(id);
            if (studentToEdit != null)
            {
                studentToEdit.FirstName = student.FirstName;
                studentToEdit.LastName = student.LastName;
                studentToEdit.CollegeId = student.CollegeId;

                await _studentRepository.UpdateAsync(studentToEdit);
            }
        }
    }
}
