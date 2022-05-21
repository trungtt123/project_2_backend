
namespace WareHouse.Core.Models
{
    //user trong bảng quản lý
    public class UserDataDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string givenName { get; set; }
        public string surName { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }

    }
}
