using System.ComponentModel.DataAnnotations;

namespace DentalOffice.Dtos
{
    public record AppointmentDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public int DentistId { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        [Required]
        public int UserId { get; set; }
        public string ClientFullName { get; set; }
        public string DentistFullName { get; set; }
        public string TreatmentName { get; set; }
    }
}
