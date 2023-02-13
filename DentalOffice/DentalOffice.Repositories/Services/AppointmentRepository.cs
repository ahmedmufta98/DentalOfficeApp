using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.Repositories.Services
{
    public class AppointmentRepository : BaseRepository<int, AppointmentDto, AppointmentSearchRequestDto, Appointment>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AppointmentRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<AppointmentDto>> GetAll(AppointmentSearchRequestDto? searchRequest)
        {
            var appointments = _context.Appointments.Include(p => p.User).Include(p => p.Treatment).Select(p => new Appointment
            {
                Id = p.Id,
                Start = p.Start,
                End = p.End,
                UserId = p.UserId,
                TreatmentId = p.TreatmentId,
                DentistId = p.DentistId,
                ClientFullName = p.User.FirstName + " " + p.User.LastName,
                TreatmentName = p.Treatment.Name,
                DentistFullName = p.Dentist.FirstName + " " + p.Dentist.LastName
            }).AsQueryable();


            if (searchRequest.Start is not null && searchRequest.End is not null)
                appointments = appointments.Where(a => a.Start >= searchRequest.Start && a.End <= searchRequest.End);

            if (searchRequest.DentistId is not null)
                appointments = appointments.Where(a => a.DentistId == searchRequest.DentistId);

            if (searchRequest.TreatmentId is not null)
                appointments = appointments.Where(a => a.TreatmentId == searchRequest.TreatmentId);

            if (searchRequest.UserId is not null)
                appointments = appointments.Where(a => a.UserId == searchRequest.UserId);

            return _mapper.Map<List<AppointmentDto>>(await appointments.ToListAsync());
        }
    }
}
