using Horse.Api.Dtos;
using Horse.Business;
using Horse.Business.Models;
using Horse.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace Horse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightGoalController : ControllerBase
    {
        private readonly IWeightGoalRepository _goalRepository;

        public WeightGoalController(IWeightGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        [HttpGet]
        public IActionResult GetGoal(int Id)
        {
            var weightGoal = _goalRepository.Get(Id);
            if (weightGoal == null)
            {
                return BadRequest();
            }

            return Ok(weightGoal);
        }

        [HttpPost]
        public IActionResult PostGoal([FromBody] WeightGoalDto weightGoalDto)
        {
            var weightGoal = new WeightGoal 
            { 
                EndDate = weightGoalDto.EndDate, 
                StartDate = weightGoalDto.StartDate,
                TargetWeight = weightGoalDto.TargetWeight,
                CurrentWeight = weightGoalDto.CurrentWeight,
                Unit = weightGoalDto.Unit
            };

            try
            {
                _goalRepository.Add(weightGoal);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}