using Microsoft.AspNetCore.Mvc;
using Zadanie_6.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace Zadanie_6
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        private readonly IDatabaseService _dbService;

        public AnimalsController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_dbService.GetAnimals());
        }

        [Route("animal/{id}")]
        [HttpGet]
        public IActionResult GetQuery(int id)
        {
            Models.Animal zwierze = _dbService.GetAnimal(id);
            return Ok(zwierze);
        }

        [HttpPost("createAnimal")]
        public void Post([FromBody] Models.Animal animal)
        {
            _dbService.AddAnimal(animal);
        }

        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] Models.Animal animal)
        {
            Models.Animal zwierze = _dbService.GetAnimal(id);
            animal = zwierze;
            _dbService.UpdateAnimal(animal);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteAnimal(int id)
        {
            _dbService.DeleteAnimal(id);
        }
    }
}
