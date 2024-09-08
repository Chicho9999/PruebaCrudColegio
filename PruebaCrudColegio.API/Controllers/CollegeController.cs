using Microsoft.AspNetCore.Mvc;
using PruebaCrudColegio.Application.Interface;

namespace PruebaCrudColegio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var grades = await _collegeService.GetAllGrades();

            return Ok(grades);
        }
    }
}