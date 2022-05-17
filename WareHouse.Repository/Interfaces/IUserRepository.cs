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

        public UserEntity GetUser(int userId);

        public UserEntity CreateUser(UserEntity userData);
        public bool DeleteUser(int userId);

        public bool UpdateUser(UserEntity newUserData); 
        public List<UserEntity> GetAllUsers();

        public List<RoleEntity> GetListPermissions();

        public bool ChangePassWord(int userId, string newPassWord);
    }
}
