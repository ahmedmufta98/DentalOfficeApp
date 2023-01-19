using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/payments"), Authorize]
    [ApiController]
    public class PaymentsController : BaseController<int, PaymentDto, PaymentSearchRequestDto, Payment>
    {
        public PaymentsController(IBaseRepository<int, PaymentDto, PaymentSearchRequestDto, Payment> repository) : base(repository)
        {
        }
    }
}
