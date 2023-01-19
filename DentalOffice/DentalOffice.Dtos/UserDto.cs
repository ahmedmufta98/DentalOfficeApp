using DentalOffice.Enums;
using System.ComponentModel.DataAnnotations;

namespace DentalOffice.Dtos
{
    public record UserDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public byte[]? Image { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
