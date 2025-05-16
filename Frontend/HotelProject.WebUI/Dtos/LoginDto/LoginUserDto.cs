using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Enter you username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Enter you password")]
        public string? Password { get; set; }
    }
}
