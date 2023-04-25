namespace MDS_Tour.Areas.Admin.Models
{
    public class VisitorModel
    {
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Mail { get; set; }
    }
}
