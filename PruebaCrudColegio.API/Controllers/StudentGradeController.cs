using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application.Interface;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentGradeController : ControllerBase
    {
        private readonly IStudentGradeService _studentGradeService;

        public StudentGradeController(IStudentGradeService studentGradeService)
        {
            _studentGradeService = studentGradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var studentGrades = await _studentGradeService.GetAllStudentGradesAsync();

            return Ok(studentGrades);
        }

        [HttpGet]
        [Route("ByStudentId/{id}")]
        public async Task<IActionResult> GetStudentGradesByStudentIdAsync(Guid id)
        {
            var studentGrades = await _studentGradeService.GetAllStudentGradesByUserIdAsync(id);

            return Ok(studentGrades);
        }

        [HttpPut]
        [Route("updateStudentGrades/{id}")]
        public async Task<IActionResult> GetStudentGradesByStudentIdAsync(Guid id, List<StudentGradeDto> studentGrades)
        {
            var result = await _studentGradeService.UpdateStudentGradesAsync(id, studentGrades);

            return Ok(result);
        }
    }
}