namespace DentalOffice.Dtos
{
    public record UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
