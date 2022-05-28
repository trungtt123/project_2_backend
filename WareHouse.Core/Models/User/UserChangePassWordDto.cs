
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    public class UserChangePassWordDto
    {    
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
