using System.ComponentModel.DataAnnotations;

namespace MDS_Tour.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your password!")]
        [Compare("Password", ErrorMessage = "Passwords are not compatible please check")]
        public string ConfirmPassword { get; set; }

    }
}
