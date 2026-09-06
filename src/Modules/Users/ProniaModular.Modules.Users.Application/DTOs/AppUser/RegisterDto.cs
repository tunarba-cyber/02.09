using ProniaModular.Modules.Users.Domain.Enums;

namespace ProniaModular.Modules.Users.Application.DTOs.AppUser
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserGender UserGender { get; set; }
    }
}