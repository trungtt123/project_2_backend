
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    public class UserLoginDto
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
