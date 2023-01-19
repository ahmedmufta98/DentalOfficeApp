using DentalOffice.API.Security;
using DentalOffice.Dtos;
using DentalOffice.Dtos.SearchRequests;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using DentalOffice.Repositories.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.API.Extensions
{
    public static class DIProvider
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("dbConnection")));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<int, AppointmentDto, AppointmentSearchRequestDto, Appointment>, AppointmentRepository>();
            services.AddScoped<IBaseRepository<int, DentistDto, DentistSearchRequestDto, Dentist>, DentistRepository>();
            services.AddScoped<IBaseRepository<int, DentistOfficeDto, object, DentistOffice>, BaseRepository<int, DentistOfficeDto, object, DentistOffice>>();
            services.AddScoped<IBaseRepository<int, PaymentDto, PaymentSearchRequestDto, Payment>, PaymentRepository>();
            services.AddScoped<IBaseRepository<int, RatingDto, RatingSearchRequestDto, Rating>, RatingRepository>();
            services.AddScoped<IBaseRepository<int, TreatmentDto, TreatmentSearchRequestDto, Treatment>, TreatmentRepository>();
            services.AddScoped<IBaseRepository<int, UserDto, UserSearchRequestDto, User>, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRecommendationRepository, RecommendationRepository>();
        }

        public static void AddBasicAuth(this IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }
    }
}
