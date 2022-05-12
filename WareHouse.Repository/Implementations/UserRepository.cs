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
        public UserEntity GetUser(string userName)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var user = new UserEntity();

                user = dbcontext.users.FirstOrDefault(o => o.UserName == userName);

                //userDto = mapper.Map<UserEntity, UserDto>(user);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserEntity GetUser(int userId)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                var user = new UserEntity();

                user = dbcontext.users.FirstOrDefault(o => o.UserId == userId);

                //userDto = mapper.Map<UserEntity, UserDto>(user);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserEntity CreateUser(UserEntity userData)
        {
            try
            {
                using var dbcontext = new MyDbContext();

                dbcontext.users.Add(userData);

                int number_rows = dbcontext.SaveChanges();

                if (number_rows > 0) return userData;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteUser(int userId)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                
                var user = dbcontext.users.FirstOrDefault(o => o.UserId == userId);
                
                dbcontext.users.Remove(user);

                dbcontext.SaveChanges();
               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateUser(UserEntity newUserData)
        {
           
            try
            {
                using var dbcontext = new MyDbContext();

                var user = dbcontext.users.FirstOrDefault(o => o.UserId == newUserData.UserId);

                if (user != null)
                {
                    user.SurName = newUserData.SurName;
                    user.GivenName = newUserData.GivenName;
                    user.RoleId = newUserData.RoleId;
                    dbcontext.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RoleEntity> GetListPermissions()
        {
            try
            {
                using var dbcontext = new MyDbContext();
                List<RoleEntity> arr = dbcontext.roles.ToList();
                return arr;
            }
            catch(Exception ex)
            {
                return null;
            }
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
        public bool ChangePassWord(int userId, string newPassword)
        {
            try
            {
                using var dbcontext = new MyDbContext();
                var user = dbcontext.users.FirstOrDefault(o => o.UserId == userId);
                if (user != null)
                {
                    user.Password = newPassword;
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
