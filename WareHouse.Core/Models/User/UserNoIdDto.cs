using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Models
{
    //model khi add user (chưa biết userId)
    public class UserNoIdDto
    {
        public string userName { get; set; }
        public string givenName { get; set; }
        public string surName { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }

    }
}
