using DentalOffice.Dtos;

namespace DentalOffice.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserDto> Login(UserLoginDto request);
        Task<UserDto> Register(UserDto request);
        Task<UserDto> Authenticate(string username, string password);
    }
}
