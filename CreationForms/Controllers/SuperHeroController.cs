using CreationForms.Models;
using CreationForms.Services.SuperHeroService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreationForms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        // OPTIONS: api/TodoItems2/5
        [HttpOptions("{id}")]
        public IActionResult PreflightRoute(int id)
        {
            return NoContent();
        }

        // OPTIONS: api/TodoItems2 
        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);

            if (result == null)
            {
                return NotFound("Sorry, but this hero doesn´t exist!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            var result = await _superHeroService.AddHero(newHero);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero updatedHero)
        {
            var result = await _superHeroService.UpdateHero(id, updatedHero);

            if (result == null)
            {
                return NotFound("Sorry, but this hero doesn´t exist!");
            }

            return Ok(result);
        }
        [EnableCors("CorsPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);

            if (result == null)
            {
                return NotFound("Hero not found!");
            }

            return Ok(result);
        }
    }
}
