using System.ComponentModel.DataAnnotations;

namespace MDS_Tour.Models
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderofMail { get; set; }
        [Required(ErrorMessage = "Please enter Recipient's Email!")]
        public string RecipientofMail { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter your Message!")]
        public string Content { get; set; }
    }
}
