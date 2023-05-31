using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        [Required(ErrorMessage = "Please enter City Name!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter DayNight!")]
        public string DayNight { get; set; }
        [Required(ErrorMessage = "Please enter Price!")]
        public double Price { get; set; }
        public string ?Image { get; set; }
        public string ?Description { get; set; }
        public int Capacity { get; set; }
        public bool ?Status { get; set; }
        public string ?CoverImage { get; set; }
        public string ?Details1 { get; set; }
        public string ?Image2 { get; set; }
        public string ?Details2 { get; set; }
       

        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
        [ForeignKey("GuideId")]
        public Guides? Guides { get; set; }
    }
}
