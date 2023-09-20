namespace Assistant.Service.AuthAPI.Models.Dto
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNomber { get; set; }
        public string Password { get; set; }

        public string? Role { get; set; }
    }
}
