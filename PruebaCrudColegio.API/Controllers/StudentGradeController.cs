using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Interface;
using PruebaCrudColegio.Core.Model;

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
            var studentGrades = await _studentGradeService.GetAllStudentGrades();

            return Ok(studentGrades);
        }

        [HttpGet]
        [Route("ByStudentId/{id}")]
        public async Task<IActionResult> GetStudentGradesByStudentId(Guid id)
        {
            var studentGrades = await _studentGradeService.GetAllStudentGradesByUserId(id);

            return Ok(studentGrades);
        }

        [HttpPut]
        [Route("updateStudentGrades/{id}")]
        public async Task<IActionResult> GetStudentGradesByStudentId(Guid id, List<StudentGrade> studentGrades)
        {
            var result = await _studentGradeService.UpdateStudentGrades(id, studentGrades);

            return Ok(result);
        }
    }
}