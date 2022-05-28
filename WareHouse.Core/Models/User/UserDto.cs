
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    //user lưu phía người dùng
    public class UserDto
    {

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("surName")]
        public string SurName { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
