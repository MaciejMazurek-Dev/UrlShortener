using System.ComponentModel.DataAnnotations;

namespace UrlShortenerMVC.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(30)]
        public string Email { get; set; } = String.Empty;


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string Password { get; set; } = String.Empty;
    }
}
