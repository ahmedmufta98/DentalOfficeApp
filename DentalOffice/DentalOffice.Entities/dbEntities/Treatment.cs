namespace DentalOffice.Entities.dbEntities
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimeRequiredInMinutes { get; set; }
        public byte[]? Image { get; set; }
    }
}
