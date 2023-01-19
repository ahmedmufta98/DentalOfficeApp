namespace DentalOffice.Entities.dbEntities
{
    public class Dentist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int DentistOfficeId { get; set; }
        public DentistOffice DentistOffice { get; set; }
    }
}
