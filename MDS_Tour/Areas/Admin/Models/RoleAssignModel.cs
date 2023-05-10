namespace MDS_Tour.Areas.Admin.Models
{
    public class RoleAssignModel
    {
        public int RoleId{ get; set; }
        public string RoleName{ get; set; }
        public bool RoleExist { get; set; } // Bu rol bu kullanıcı da var mı?
    }
}
