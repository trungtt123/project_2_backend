
namespace WareHouse.Core.Models
{
    //user update
    public class UserUpdateDto
    {
        public int UserId { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public int RoleId { get; set; }

        public string Email { get; set; }

    }
}
