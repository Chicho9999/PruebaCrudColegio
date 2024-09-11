using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application;
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
        [Route("ByProfessorId/{id}")]
        public async Task<IActionResult> GetGradesByProfessorId(Guid id)
        {
            var grades = await _gradeService.GetAllGradesByProfessorId(id);

            return Ok(grades);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GradeDto entity)
        {
            var grade = await _gradeService.AddGradeAsync(entity);

            if (grade == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Grade Created Successfully!!!",
                id = grade!.Id
            });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] GradeDto gradeDto)
        {
            var gradeToEdit = await _gradeService.UpdateGradeAsync(gradeDto.Id, gradeDto);

            if (gradeToEdit == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Grade Updated Successfully!!!",
                id = gradeToEdit!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _gradeService.DeleteStudentAsync(id);
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