using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/users"), Authorize]
    [ApiController]
    public class UsersController : BaseController<int, UserDto, UserSearchRequestDto, User>
    {
        public UsersController(IBaseRepository<int, UserDto, UserSearchRequestDto, User> repository) : base(repository)
        {
        }
    }
}
