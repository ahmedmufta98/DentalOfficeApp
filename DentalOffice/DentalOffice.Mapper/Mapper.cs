using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Entities.dbEntities;

namespace DentalOffice.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Dentist, DentistDto>().ReverseMap();
            CreateMap<DentistOffice, DentistOfficeDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Treatment, TreatmentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
