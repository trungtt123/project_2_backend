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
        public UserDto Authenticate(UserLoginDto userLogin);
        public UserInfomationDto CreateUser(UserNoIdDto user);
        public bool UpdateUser(UserUpdateDto newUserData);
        public bool DeleteUser(int userId);

        public UserInfomationDto GetUser(int userId);
        public bool ChangePassWord(UserChangePassWordDto userData);
        public List<RoleDto> GetListPermissions();
        public List<UserDataDto> GetAllUsers();
    }
}
