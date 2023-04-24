using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DataTrabsferObjects.MailDTOs
{
    public class MailRequestDTO
    {
        public string Name { get; set; }
        public string SenderofMail { get; set; }
        public string RecipientofMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
