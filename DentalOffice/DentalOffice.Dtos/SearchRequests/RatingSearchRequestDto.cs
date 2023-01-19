namespace DentalOffice.Dtos.SearchRequests
{
    public record RatingSearchRequestDto
    {
        public int? UserId { get; set; } = null;
        public int? DentistId { get; set; } = null;
    }
}
