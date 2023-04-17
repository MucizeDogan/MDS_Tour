using System.ComponentModel.DataAnnotations;

namespace MDS_Tour.Models
{
    public class UserRegisterViewModel
    {
        [Required (ErrorMessage ="Please enter your name")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        public string Mail { get; set; }
        
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password again")]
        [Compare("Password",ErrorMessage = "Passwords are not compatible please check")]
        public string ConfirmPassword { get; set; }
    }
}
