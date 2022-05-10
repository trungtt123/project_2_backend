using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Core.Entities;
using WareHouse.Core.Models;

namespace WareHouse.Repository.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity GetUser(string userName);

        public UserEntity CreateUser(UserEntity userData);

        public List<UserEntity> AddUser(List<UserEntity> users);
        public List<UserEntity> UpdateUser(List<UserEntity> newUsers);
        public bool DeleteUser(List<int> listUserId);

        public List<UserEntity> GetAllUsers();

        public List<RoleEntity> GetListPermissions();

        public bool ChangePassWord(int userId, string newPassWord);
    }
}
