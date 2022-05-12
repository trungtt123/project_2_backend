using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Models;


namespace WareHouse.Service.Interfaces
{
    public interface IUserService
    {
        public UserDto Authenticate(UserLogin userLogin);
        public UserInfomation CreateUser(UserNoId user);
        public bool UpdateUser(UserUpdate newUserData);
        public bool DeleteUser(int userId);

        public UserInfomation GetUser(int userId);
        public bool ChangePassWord(UserChangePassWord userData);
        public List<RoleDto> GetListPermissions();
        public List<UserData> GetAllUsers();
    }
}
