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

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var student = _studentService.GetStudentById(id);
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
        public IActionResult Post([FromBody] StudentDto entity)
        {
            var student = _studentService.AddStudent(entity);

            if (student == null)
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
        public IActionResult Put([FromBody] StudentDto studentDto)
        {
            var studentToEdit = _studentService.UpdateStudent(studentDto.Id, studentDto);
            if (studentToEdit == null)
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
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _studentService.DeleteStudent(id);
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
