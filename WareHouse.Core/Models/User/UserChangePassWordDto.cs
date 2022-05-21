
namespace WareHouse.Core.Models
{
    public class UserChangePassWordDto
    {    
        public string userName { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
