using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class DentistRepository : BaseRepository<int, DentistDto, DentistSearchRequestDto, Dentist>, IBaseRepository<int, DentistDto, DentistSearchRequestDto, Dentist>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DentistRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public override async Task<List<DentistDto>> GetAll(DentistSearchRequestDto? searchRequest)
        {
            var dentists = _context.Dentists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRequest.FirstName))
                dentists = dentists.Where(d => d.FirstName == searchRequest.FirstName);

            if (!string.IsNullOrWhiteSpace(searchRequest.LastName))
                dentists = dentists.Where(d => d.LastName == searchRequest.LastName);

            if (!string.IsNullOrWhiteSpace(searchRequest.Email))
                dentists = dentists.Where(d => d.Email == searchRequest.Email);

            if (!string.IsNullOrWhiteSpace(searchRequest.Phone))
                dentists = dentists.Where(d => d.Phone == searchRequest.Phone);

            return _mapper.Map<List<DentistDto>>(await dentists.ToListAsync());
        }
    }
}
