using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Models
{
    //model khi add user (chưa biết userId)
    public class UserNoIdDto
    {
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

    }
}
