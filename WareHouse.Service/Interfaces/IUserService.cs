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
        public List<UserInfomation> AddUser(List<UserNoId> users);
        public List<UserInfomation> UpdateUser(List<UserUpdate> newUsers);
        public bool DeleteUser(List<int> listUserId);

        public bool ChangePassWord(UserChangePassWord userData);
        public List<RoleDto> GetListPermissions();
        public List<UserData> GetAllUsers();
    }
}
