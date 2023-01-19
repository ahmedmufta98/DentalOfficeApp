using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class UserRepository : BaseRepository<int, UserDto, UserSearchRequestDto, User>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;  
        }

        public override async Task<List<UserDto>> GetAll(UserSearchRequestDto? searchRequest)
        {
            var users = _context.Users.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchRequest.FirstName))
                users = users.Where(u=>u.FirstName == searchRequest.FirstName);

            if (!string.IsNullOrWhiteSpace(searchRequest.LastName))
                users = users.Where(u => u.LastName == searchRequest.LastName);

            if (!string.IsNullOrWhiteSpace(searchRequest.Username))
                users = users.Where(u => u.Username == searchRequest.Username);

            if (searchRequest.Role is not null)
                users = users.Where(u => u.Role == searchRequest.Role);

            if (searchRequest.Gender is not null)
                users = users.Where(u => u.Gender == searchRequest.Gender);

            return _mapper.Map<List<UserDto>>(await users.ToListAsync());
        }
    }
}
