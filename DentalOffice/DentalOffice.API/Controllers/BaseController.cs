using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Tkey, Tmodel, Tsearch, Tdb> : ControllerBase where Tmodel : class where Tsearch : class where Tdb : class
    {
        private readonly IBaseRepository<Tkey, Tmodel, Tsearch, Tdb> _repository;
        public BaseController(IBaseRepository<Tkey, Tmodel, Tsearch, Tdb> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public virtual async Task<IActionResult> Create([FromBody] Tmodel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _repository.Create(model));
        }

        [HttpPost]
        [Route("filtering")]
        public virtual async Task<IActionResult> GetAllFilteredData([FromBody] Tsearch searchRequest)
        {
            return Ok(await _repository.GetAll(searchRequest));
        }

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> GetAll([FromQuery] Tsearch searchRequest)
        {
            return Ok(await _repository.GetAll(searchRequest));
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetById(Tkey id)
        {
            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _repository.GetById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Update([FromRoute] Tkey id, [FromBody] Tmodel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _repository.Update(id, model));
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete(Tkey id)
        {
            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _repository.Delete(id));
        }
    }
}
