using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WareHouse.Core.Models
{
    //model khi add user (chưa biết userId)
    public class UserNoIdDto
    {

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("surName")]
        public string SurName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

    }
}
