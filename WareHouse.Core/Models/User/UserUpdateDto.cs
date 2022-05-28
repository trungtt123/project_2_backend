
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    //user update
    public class UserUpdateDto
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("surName")]
        public string SurName { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
