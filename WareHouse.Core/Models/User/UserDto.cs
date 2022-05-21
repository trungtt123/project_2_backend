
namespace WareHouse.Core.Models
{
    //user lưu phía người dùng
    public class UserDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string givenName { get; set; }
        public string surName { get; set; }
        public int roleId { get; set; }
        public string token { get; set; }
        public string email { get; set; }
    }
}
