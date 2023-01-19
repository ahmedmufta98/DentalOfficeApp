using DentalOffice.Enums;

namespace DentalOffice.Dtos.SearchRequests
{
    public record UserSearchRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role? Role { get; set; } = null;
        public Gender? Gender { get; set; } = null;
    }
}
