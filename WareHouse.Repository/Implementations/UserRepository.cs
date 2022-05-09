using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Repository.Interfaces;
using WareHouse.Core.Entities;

namespace WareHouse.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        public bool CheckUserNameAlreadyExists(string username)
        {
            using var dbcontext = new MyDbContext();

            var user = dbcontext.users.FirstOrDefault(o => o.UserName == username);

            if (user == null) return false;

            return true;
        }

        public UserEntity GetUser(string userName)
        {
            using var dbcontext = new MyDbContext();

            var user = new UserEntity();

            user = dbcontext.users.FirstOrDefault(o => o.UserName == userName);

            //userDto = mapper.Map<UserEntity, UserDto>(user);
            return user;
        }

        public UserEntity CreateUser(UserEntity userData)
        {
            using var dbcontext = new MyDbContext();

            dbcontext.users.Add(userData);

            int number_rows = dbcontext.SaveChanges();

            if (number_rows > 0) return userData;
            return null;

        }
        public List<UserEntity> AddUser(List<UserEntity> users)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                Console.WriteLine(users);
                dbcontext.users.AddRange(users);
                dbcontext.SaveChanges();
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<UserEntity> UpdateUser(List<UserEntity> newUsers)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                foreach (var newUser in newUsers)
                {
                    var user = dbcontext.users.FirstOrDefault(o => o.UserId == newUser.UserId);
                    if (user != null)
                    {
                        user.SurName = newUser.SurName;
                        user.GivenName = newUser.GivenName;
                        user.RoleId = newUser.RoleId;
                        dbcontext.SaveChanges();
                    }
                    else return null;
                }
                
                return newUsers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteUser(List<int> listUserId)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                foreach (var userId in listUserId)
                {
                    var user = dbcontext.users.FirstOrDefault(o => o.UserId == userId);
                    dbcontext.users.Remove(user);
                }
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<RoleEntity> GetListPermissions()
        {
            using var dbcontext = new MyDbContext();
            List<RoleEntity> arr = dbcontext.roles.ToList();
            return arr;
        }
        public List<UserEntity> GetAllUsers()
        {
            try
            {
                using var dbcontext = new MyDbContext();
                List<UserEntity> arr = dbcontext.users.ToList();
                return arr;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public bool ChangePassWord(int userId, string newPassWord)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                var user = dbcontext.users.FirstOrDefault(o => o.UserId == userId);
                if (user != null)
                {
                    user.PassWord = newPassWord;
                    dbcontext.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
