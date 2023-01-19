using System.ComponentModel.DataAnnotations.Schema;

namespace DentalOffice.Entities.dbEntities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        public string ClientFullName { get; set; }
        [NotMapped]
        public string DentistFullName { get; set; }
        [NotMapped]
        public string TreatmentName { get; set; }
    }
}
