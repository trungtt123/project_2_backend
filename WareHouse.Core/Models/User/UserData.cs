
namespace WareHouse.Core.Models
{
    //user trong bảng quản lý
    public class UserData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public int RoleId { get; set; }

    }
}
