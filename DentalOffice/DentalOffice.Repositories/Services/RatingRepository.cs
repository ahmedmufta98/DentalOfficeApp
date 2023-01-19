using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class RatingRepository : BaseRepository<int, RatingDto, RatingSearchRequestDto, Rating>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RatingRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<RatingDto>> GetAll(RatingSearchRequestDto? searchRequest)
        {
            var ratings = _context.Ratings.Include(r => r.User).Include(r => r.Dentist).Select(r => new Rating
            {
                Id= r.Id,
                DentistId = r.DentistId,
                UserId = r.UserId,
                Rate = r.Rate,
                Comment = r.Comment,
                Date = r.Date,
                ClientFullName = r.User.FirstName + " " + r.User.LastName,
                DentistFullName = r.Dentist.FirstName + " " + r.Dentist.LastName
            }).AsQueryable();

            if (searchRequest.UserId is not null)
                ratings = ratings.Where(r => r.UserId == searchRequest.UserId);

            if (searchRequest.DentistId is not null)
                ratings = ratings.Where(r => r.DentistId == searchRequest.DentistId);

            return _mapper.Map<List<RatingDto>>(await ratings.ToListAsync());
        }
    }
}
