using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class PaymentRepository : BaseRepository<int, PaymentDto, PaymentSearchRequestDto, Payment>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<PaymentDto>> GetAll(PaymentSearchRequestDto? searchRequest)
        {
            var payments = _context.Payments.Include(p => p.User).Include(p => p.Treatment).Select(p => new Payment
            {
                Id = p.Id,
                Amount = p.Amount,
                Date = p.Date,
                CardNumber = p.CardNumber,
                UserId = p.UserId,
                TreatmentId = p.TreatmentId,
                Client = p.User.FirstName + " " + p.User.LastName,
                TreatmentName = p.Treatment.Name
            }).AsQueryable();

            if (searchRequest.Date is not null)
                payments = payments.Where(p => p.Date == searchRequest.Date);

            if (searchRequest.TreatmentId is not null)
                payments = payments.Where(p => p.TreatmentId == searchRequest.TreatmentId);

            if (searchRequest.UserId is not null)
                payments = payments.Where(p => p.UserId == searchRequest.UserId);

            if (!string.IsNullOrWhiteSpace(searchRequest.CardNumber))
                payments = payments.Where(p => p.CardNumber == searchRequest.CardNumber);

            return _mapper.Map<List<PaymentDto>>(await payments.ToListAsync());
        }
    }
}
