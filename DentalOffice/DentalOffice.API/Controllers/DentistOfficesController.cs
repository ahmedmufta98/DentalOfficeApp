using DentalOffice.Dtos;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/dentistoffices"), Authorize]
    [ApiController]
    public class DentistOfficesController : BaseController<int, DentistOfficeDto, object, DentistOffice>
    {
        public DentistOfficesController(IBaseRepository<int, DentistOfficeDto, object, DentistOffice> repository) : base(repository)
        {
        }
    }
}
