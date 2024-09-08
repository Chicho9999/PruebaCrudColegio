using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Interface;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var grades = await _gradeService.GetAllGrades();

            return Ok(grades);
        }

        [HttpGet]
        [Route("ByStudentId/{id}")]
        public async Task<IActionResult> GetGradesByStudentId(Guid id)
        {
            var grades = await _gradeService.GetAllGradesByUserId(id);

            return Ok(grades);
        }
    }
}