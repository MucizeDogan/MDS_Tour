namespace MDS_Tour.Areas.Admin.Models
{
    public class AccountModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
