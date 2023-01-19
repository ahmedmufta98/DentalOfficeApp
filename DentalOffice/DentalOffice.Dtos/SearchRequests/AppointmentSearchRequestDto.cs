namespace DentalOffice.Dtos.SearchRequests
{
    public record AppointmentSearchRequestDto
    {
        public DateTime? Start { get; set; } = null;
        public DateTime? End { get; set; } = null;
        public int? DentistId { get; set; } = null;
        public int? TreatmentId { get; set; } = null;
        public int? UserId { get; set; } = null;
    }
}
