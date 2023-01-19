namespace DentalOffice.Dtos.SearchRequests
{
    public record PaymentSearchRequestDto
    {
        public DateTime? Date { get; set; } = null;
        public int? UserId { get; set; } = null;
        public string CardNumber { get; set; } = string.Empty;
        public int? TreatmentId { get; set; } = null;
    }
}
