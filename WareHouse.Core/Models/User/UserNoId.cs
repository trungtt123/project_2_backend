using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WareHouse.Core.Models
{
    //model khi add user (chưa biết userId)
    public class UserNoId
    {
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public int RoleId { get; set; }

    }
}
