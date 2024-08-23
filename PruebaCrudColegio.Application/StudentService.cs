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

        public bool DeleteStudent(Guid id)
        {
            var studentToDelete = _studentRepository.GetById(id);
            if (studentToDelete != null) { 
                _studentRepository.Delete(studentToDelete);
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

        public Student? GetStudentById(Guid id)
        {
            return _studentRepository.GetById(id);
        }

        public Student? UpdateStudent(Guid id, StudentDto studentDto)
        {
            var student = MapStudent(studentDto);

            var studentToEdit = _studentRepository.GetById(id);
            if (studentToEdit != null)
            {
                studentToEdit.FirstName = student.FirstName;
                studentToEdit.LastName = student.LastName;
                studentToEdit.CollegeId = student.CollegeId;

                _studentRepository.Update(studentToEdit);

                return studentToEdit;
            }

            return null;
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
