using System.ComponentModel.DataAnnotations.Schema;

namespace DentalOffice.Entities.dbEntities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }

        [NotMapped]
        public string DentistFullName { get; set; }
        [NotMapped]
        public string ClientFullName { get; set; }
    }
}
