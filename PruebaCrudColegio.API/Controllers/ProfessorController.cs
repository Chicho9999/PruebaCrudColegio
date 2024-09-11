using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Dtos;
using PruebaCrudColegio.Application;
using PruebaCrudColegio.Application.Interface;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var professors = await _professorService.GetAllProfessors();

            return Ok(professors);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProfessorDto entity)
        {
            var professor = await _professorService.AddProfessorAsync(entity);

            if (professor == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Professor Created Successfully!!!",
                id = professor!.Id
            });
        }



        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ProfessorDto professorDto)
        {
            var professorToEdit = await _professorService.UpdateProfessorAsync(professorDto.Id, professorDto);

            if (professorToEdit == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Professor Updated Successfully!!!",
                id = professorToEdit!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _professorService.DeleteStudentAsync(id);
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