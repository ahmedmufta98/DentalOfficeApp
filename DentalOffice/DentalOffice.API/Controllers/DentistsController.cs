using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/dentists")]
    [ApiController]
    public class DentistsController : BaseController<int, DentistDto, DentistSearchRequestDto, Dentist>
    {
        public DentistsController(IBaseRepository<int, DentistDto, DentistSearchRequestDto, Dentist> repository) : base(repository)
        {
        }
    }
}
