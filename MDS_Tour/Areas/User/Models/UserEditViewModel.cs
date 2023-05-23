using System.ComponentModel.DataAnnotations;

namespace MDS_Tour.Areas.User.Models
{
    public class UserEditViewModel
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        [DataType("Password")]
        public string? password { get; set; }
        [Compare("password", ErrorMessage = "Passwords are not compatible please check")]
        public string? confirmpassword { get; set; }
        public string? phonenumber { get; set; }
        public string? mail { get; set; }
        public string? imageurl { get; set; }
        public IFormFile? Image { get; set; }

    }
}
