using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/treatments"), Authorize]
    [ApiController]
    public class TreatmentsController : BaseController<int, TreatmentDto, TreatmentSearchRequestDto, Treatment>
    {
        public TreatmentsController(IBaseRepository<int, TreatmentDto, TreatmentSearchRequestDto, Treatment> repository) : base(repository)
        {
        }
    }
}
