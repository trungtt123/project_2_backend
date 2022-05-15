
namespace WareHouse.Core.Models
{
    //user lưu phía người dùng
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
