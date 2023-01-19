using System.ComponentModel.DataAnnotations;

namespace DentalOffice.Dtos
{
    public record DentistDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int DentistOfficeId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
