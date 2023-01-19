using DentalOffice.Enums;

namespace DentalOffice.Entities.dbEntities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public byte[]? Image { get; set; }
    }
}
