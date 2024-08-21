using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student entity)
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
        [Route("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] Student student)
        {
            var studentToEdit = _studentService.UpdateStudent(id, student);
            if (studentToEdit == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Student Updated Successfully!!!",
                id = studentToEdit!.Id
            });
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if (!_studentService.DeleteStudent(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
