
namespace WareHouse.Core.Models
{
    //user update
    public class UserUpdateDto
    {
        public int userId { get; set; }
        public string givenName { get; set; }
        public string surName { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }

    }
}
