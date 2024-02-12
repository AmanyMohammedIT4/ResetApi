using Microsoft.AspNetCore.Mvc;
using ResetApi.DataAccess.Dapper;
using ResetApi.Domain;
using ResetApi.Services;

namespace ResetApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeveloperController:ControllerBase
    {
        protected readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var developers = await _developerService.GetAllDevelopers();
            return Ok(developers);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDeveloperById(int Id)
        {
            var developers = await _developerService.GetDeveloperById(Id);
            return Ok(developers);
        }
        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeveloperByEmail(string Email)
        {
            var developers = await _developerService.GetDeveloperByEmail(Email);
            return Ok(developers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid) return BadRequest();

            _developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetAllDeveloperById), new {Id = developer.Id},developer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid) return BadRequest();
            _developerService.UpdateDeveloper(developer);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteDeveloper(int Id)
        {
            _developerService.DeleteDeveloper(Id);
            return Ok();
        }
    }
}
