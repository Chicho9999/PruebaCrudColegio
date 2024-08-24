using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class StudentService : IStudentService
    {
        readonly IRepository<Student> _studentRepository;
        readonly IRepository<College> _collegeRepository;
        readonly IRepository<Professor> _professorRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<College> collegeRepository, IRepository<Professor> professorRepository) {
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
            _professorRepository = professorRepository;
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
            return students.Select(x =>
            {
                var professor = _professorRepository.GetById(x.ProfessorId);
                var college = _collegeRepository.GetById(x.CollegeId);
                return new StudentDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CollegeId = x.CollegeId,
                    CollegeName = college?.Name,
                    ProfessorId = x.ProfessorId,
                    ProfessorName = professor?.FirstName + " " + professor?.LastName,
                };
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
                studentToEdit.ProfessorId = student.ProfessorId;

                _studentRepository.Update(studentToEdit);

                return studentToEdit;
            }

            return null;
        }

        private static Student MapStudent(StudentDto studentDto)
        {
            return new Student()
            {
                ProfessorId = studentDto.ProfessorId,
                CollegeId = studentDto.CollegeId,
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName
            };
        }
    }
}
