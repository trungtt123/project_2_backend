using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WAREHOUSE.Models
{

    public class User
    {
        //public int UserId { get; set; }


        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Role { get; set; }

    }
}
