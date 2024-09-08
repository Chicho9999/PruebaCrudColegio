using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IRepository<Professor> _professorRepository;
        private readonly IRepository<StudentGrade> _studentGradeRepository;

        public StudentService(IRepository<Student> studentRepository,
                              IRepository<Grade> gradeRepository,
                              IRepository<Professor> professorRepository,
                              IRepository<StudentGrade> studentGradeRepository) {
            _studentRepository = studentRepository;
            _gradeRepository = gradeRepository;
            _professorRepository = professorRepository;
            _studentGradeRepository = studentGradeRepository;
        }
        
        public async Task<Student> AddStudent(StudentDto studentDto)
        {
            Student student = MapStudent(studentDto);

            await _studentRepository.AddAsync(student);

            return student;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudent(Guid id)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(id);
            if (studentToDelete != null) { 
                await _studentRepository.Delete(studentToDelete);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<StudentDto>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(student =>
            {
                return new StudentDto()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gender = student.Gender,
                    BirthDay = student.BirthDay,
                };
            }).ToList();
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student?> UpdateStudent(Guid id, StudentDto studentDto)
        {
            var student = MapStudent(studentDto);

            var studentToEdit = await _studentRepository.GetByIdAsync(id);
            if (studentToEdit != null)
            {
                studentToEdit.FirstName = student.FirstName;
                studentToEdit.LastName = student.LastName;
                studentToEdit.Gender = student.Gender;
                studentToEdit.BirthDay = student.BirthDay;

                await _studentRepository.UpdateAsync(studentToEdit);

                return studentToEdit;
            }

            return null;
        }

        private static Student MapStudent(StudentDto studentDto)
        {
            return new Student()
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Gender = studentDto.Gender,
                BirthDay = studentDto.BirthDay,
            };
        }
    }
}
