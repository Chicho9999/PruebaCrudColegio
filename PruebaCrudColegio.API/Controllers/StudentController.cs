using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentGradeService _studentGradeService;

        public StudentController(IStudentService studentService, IStudentGradeService studentGradeService)
        {
            _studentService = studentService;
            _studentGradeService = studentGradeService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.GetAllStudents();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StudentDto entity)
        {
            var student = await _studentService.AddStudentAsync(entity);

            if (student == null)
            {
                return BadRequest();
            }

            foreach (var item in entity.Grades)
            {
                item.StudentId = student.Id;
            }

            var result = await _studentGradeService.UpdateStudentGradesAsync(student.Id, entity.Grades);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Student Created Successfully!!!",
                id = student!.Id
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] StudentDto studentDto)
        {
            var studentToEdit = await _studentService.UpdateStudentAsync(studentDto.Id, studentDto);
            var result = await _studentGradeService.UpdateStudentGradesAsync(studentDto.Id, studentDto.Grades);
            if (studentToEdit == null || !result)
            {
                return NotFound();
            }

            return Ok(new
            {
                student = studentToEdit,
                message = "Student Updated Successfully!!!",
                id = studentToEdit!.Id
            });
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Student Deleted Successfully!!!",
                id = id
            });
        }
    }
}
