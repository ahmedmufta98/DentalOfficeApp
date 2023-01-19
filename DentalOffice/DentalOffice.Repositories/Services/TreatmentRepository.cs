using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class TreatmentRepository : BaseRepository<int, TreatmentDto, TreatmentSearchRequestDto, Treatment>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TreatmentRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;  
        }

        public override async Task<List<TreatmentDto>> GetAll(TreatmentSearchRequestDto? searchRequest)
        {
            var treatments = _context.Treatments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchRequest.Name))
                treatments = treatments.Where(t => t.Name == searchRequest.Name);

            return _mapper.Map<List<TreatmentDto>>(await treatments.ToListAsync());
        }
    }
}
