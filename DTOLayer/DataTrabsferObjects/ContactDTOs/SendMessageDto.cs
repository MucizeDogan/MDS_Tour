using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DataTrabsferObjects.ContactDTOs
{
    public class SendMessageDto
    {
        [Required(ErrorMessage = "Please enter your Name!")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter your Mail!")]
        public string? Mail { get; set; }
        [Required(ErrorMessage = "Please enter your Subject!")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Please enter your Message!")]
        public string? MessageBody { get; set; }
        public DateTime? MessageDate { get; set; }
        public bool Status { get; set; }
    }
}
