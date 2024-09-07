using System.ComponentModel.DataAnnotations;

namespace UrlShortenerMVC.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Required(ErrorMessage = "Confirm password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two passwords you entered do not match.")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
