using Horse.Business.Interfaces;
using Horse.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Horse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightProgressController : ControllerBase
    {
        private readonly IWeightGoalRepository _goalRepository;
        private readonly IWeightEntryRepository _weightEntryRepository;
        private readonly IWeightProgressCalculator _weightProgressCalculator;

        public WeightProgressController(
            IWeightGoalRepository goalRepository, 
            IWeightEntryRepository weightEntryRepository,
            IWeightProgressCalculator weightProgressCalculator)
        {
            // ToDo refactor - Inject IWeightGoalRepository and IWeightEntryRepository into the IWeightProgressCalculator instead of having it injected in the controller..

            _goalRepository = goalRepository;
            _weightEntryRepository = weightEntryRepository;
            _weightProgressCalculator = weightProgressCalculator;
        }

        // GET api/<WeightProgressController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var goal = _goalRepository.Get(id);
            if (goal == null)
            {
                // Goal not found :(
                return NotFound();
            }

            var weightEntries = _weightEntryRepository.GetByGoalId(id);
            if (weightEntries == null)
            {
                // Weight entries not found :(
                return NotFound();
            }

            var progressInPercent = _weightProgressCalculator.CalculateCurrentProgressInPercent(goal, weightEntries);

            if (progressInPercent == null)
            {
                return BadRequest();
            }

            return Ok(progressInPercent);
        }
    }
}
