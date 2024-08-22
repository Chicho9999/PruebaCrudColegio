using PruebaCrudColegio.Application.Dtos;
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
        
        public async Task<Student> AddStudent(StudentDto studentDto)
        {
            Student student = MapStudent(studentDto);

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

        public async Task<IList<StudentDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(x => new StudentDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CollegeId = x.CollegeId,
            }).ToList();
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateStudent(Guid id, StudentDto studentDto)
        {
            var student = MapStudent(studentDto);

            var studentToEdit = await _studentRepository.GetByIdAsync(id);
            if (studentToEdit != null)
            {
                studentToEdit.FirstName = student.FirstName;
                studentToEdit.LastName = student.LastName;
                studentToEdit.CollegeId = student.CollegeId;

                await _studentRepository.UpdateAsync(studentToEdit);
            }
        }

        private static Student MapStudent(StudentDto studentDto)
        {
            return new Student()
            {
                CollegeId = studentDto.CollegeId,
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
            };
        }
    }
}
