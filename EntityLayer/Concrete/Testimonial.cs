using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]   //Primary Key olduğunu belirtiyoruz.
        public int TestimonialId{ get; set; }
        public string Client{ get; set; }
        public string Command { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
