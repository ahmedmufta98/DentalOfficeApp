using System.ComponentModel.DataAnnotations;

namespace DentalOffice.Dtos
{
    public record RatingDto
    {
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DentistId { get; set; }
        public string DentistFullName { get; set; }
        public string ClientFullName { get; set; }
    }
}
