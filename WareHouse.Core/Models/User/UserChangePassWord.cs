
namespace WareHouse.Core.Models
{
    public class UserChangePassWord
    {    
        public string UserName { get; set; }
        public string OldPassWord { get; set; }
        public string NewPassWord { get; set; }
    }
}
