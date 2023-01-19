using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/appointments"), Authorize]
    [ApiController]
    public class AppointmentsController : BaseController<int, AppointmentDto, AppointmentSearchRequestDto, Appointment>
    {
        public AppointmentsController(IBaseRepository<int, AppointmentDto, AppointmentSearchRequestDto, Appointment> repository) : base(repository)
        {
        }
    }
}
