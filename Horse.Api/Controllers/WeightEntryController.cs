using Horse.Api.Dtos;
using Horse.Business.Models;
using Horse.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Horse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightEntryController : ControllerBase
    {
        private readonly IWeightGoalRepository _goalRepository;
        private readonly IWeightEntryRepository _weightEntryRepository;

        public WeightEntryController(
            IWeightGoalRepository goalRepository, 
            IWeightEntryRepository weightEntryRepository)
        {
            _goalRepository = goalRepository;
            _weightEntryRepository = weightEntryRepository;
        }

        // GET api/<WeightEntryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var weightEntry = _weightEntryRepository.Get(id);

            if (weightEntry == null)
            {
                // Weight entry not found :(
                return NotFound();
            }

            var weightEntryDto = new WeightEntryDto
            {
                CurrentWeight = weightEntry.CurrentWeight,
                Description = weightEntry.Description,
            };

            return Ok(weightEntryDto);
        }

        // POST api/<WeightEntryController>
        [HttpPost]
        public IActionResult Post([FromBody] WeightEntryDto weightEntryDto)
        {
            // ToDo Add "Exists" method that would return bool instead of the whole object being read from persistence
            var weightGoal = _goalRepository.Get(weightEntryDto.GoalId);

            if (weightGoal == null)
            {
                // The goal is not found - can't add the entry
                return BadRequest();
            }

            var weightEntry = new WeightEntry
            {
                GoalId = weightEntryDto.GoalId,
                CurrentWeight = weightEntryDto.CurrentWeight,
                Description = weightEntryDto.Description,
                EntryDateTime = DateTime.Now
            };

            try
            {
                _weightEntryRepository.Add(weightEntry);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<WeightEntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<WeightEntryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
