
namespace WareHouse.Core.Models
{
    public class UserChangePassWord
    {    
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
