using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Repository.Interfaces;
using WareHouse.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace WareHouse.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbcontext;
      
        public UserRepository()
        {
            _dbcontext = new MyDbContext();
        }
        public UserEntity GetUser(string userName)
        {
            try
            {
                var user = new UserEntity();

                user = _dbcontext.Users.FirstOrDefault(o => o.UserName == userName);

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

                var user = new UserEntity();

                user = _dbcontext.Users.FirstOrDefault(o => o.UserId == userId);

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

                _dbcontext.Users.Add(userData);

                int number_rows = _dbcontext.SaveChanges();

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
                var user = _dbcontext.Users.FirstOrDefault(o => o.UserId == userId);
                
                _dbcontext.Users.Remove(user);

                _dbcontext.SaveChanges();
               
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

                var user = _dbcontext.Users.FirstOrDefault(o => o.UserId == newUserData.UserId);

                if (user != null)
                {
                    user.SurName = newUserData.SurName;
                    user.GivenName = newUserData.GivenName;
                    user.RoleId = newUserData.RoleId;
                    _dbcontext.SaveChanges();
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
                List<RoleEntity> arr = _dbcontext.Roles.ToList();
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
                List<UserEntity> arr = _dbcontext.Users.ToList();
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
                var user = _dbcontext.Users.FirstOrDefault(o => o.UserId == userId);
                if (user != null)
                {
                    user.Password = newPassword;
                    _dbcontext.SaveChanges();
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
