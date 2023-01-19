using DentalOffice.Dtos;

namespace DentalOffice.Repositories.Interfaces
{
    public interface IRecommendationRepository
    {
        Task<List<DentistDto>> GetRecommendedDentists(int dentistId);
    }
}
