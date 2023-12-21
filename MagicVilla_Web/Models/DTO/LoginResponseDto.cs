namespace MagicVilla_Web.Models.DTO
{
    public class LoginResponseDto
    {
        public UserDto user { get; set; }

        public string Token { get; set; }
    }
}
