﻿
namespace WareHouse.Core.Models
{
    // user sau khi được tạo (thông báo cho admin)
    public class UserInfomationDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string givenName { get; set; }
        public string surName { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }

    }
}
