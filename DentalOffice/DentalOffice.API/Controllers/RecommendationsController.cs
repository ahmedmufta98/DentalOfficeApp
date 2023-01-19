using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/recommendations")]
    [ApiController]
    [Authorize]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationRepository _repository;
        public RecommendationsController(IRecommendationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> RecommendDentist([FromRoute] int id)
        {
            return Ok(await _repository.GetRecommendedDentists(id));
        }
    }
}
