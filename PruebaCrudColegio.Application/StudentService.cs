using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;
using PruebaCrudColegio.Infrastructure.Repositories.Interface;

namespace PruebaCrudColegio.Application
{
    public class StudentService : IStudentService
    {
        readonly IRepository<Student> _studentRepository;
        readonly IRepository<Grade> _collegeRepository;
        readonly IRepository<Professor> _professorRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Grade> collegeRepository, IRepository<Professor> professorRepository) {
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
            return students.Select(x =>
            {
                var professor = _professorRepository.GetByIdAsync(x.ProfessorId).Result;
                var grade = _collegeRepository.GetByIdAsync(x.CollegeId).Result;
                return new StudentDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CollegeId = x.CollegeId,
                    CollegeName = grade?.Name,
                    ProfessorId = x.ProfessorId,
                    ProfessorName = professor?.FirstName + " " + professor?.LastName,
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
                studentToEdit.CollegeId = student.CollegeId;
                studentToEdit.ProfessorId = student.ProfessorId;

                await _studentRepository.UpdateAsync(studentToEdit);

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
