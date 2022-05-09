
namespace WareHouse.Core.Models
{
    // user sau khi được tạo (thông báo cho admin)
    public class UserInfomation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public int RoleId { get; set; }

    }
}
