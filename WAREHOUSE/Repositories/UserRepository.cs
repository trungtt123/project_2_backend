
using AutoMapper;
using WAREHOUSE.Models;
using WAREHOUSE.Entities;

namespace WAREHOUSE.Repositories
{
    public interface IUserRepository
    {
        public bool CheckUserNameAlreadyExists(string userName);

        public UserEntity GetUser(string userName);

        public UserEntity CreateUser(UserEntity userData);

        public bool DeleteUser(string userName);
    }

    public class UserRepository : IUserRepository
    {
  
        
        public bool CheckUserNameAlreadyExists(string userName)
        {
            using var dbcontext = new MyDbContext();

            var user = dbcontext.users.FirstOrDefault(o => o.UserName == userName);

            if (user == null) return false;

            return true;
        }

        public UserEntity GetUser(string userName)
        {
            using var dbcontext = new MyDbContext();
            var userDto = new UserDto();
            var user = new UserEntity();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            user = dbcontext.users.FirstOrDefault(o => o.UserName == userName);

            //userDto = mapper.Map<UserEntity, UserDto>(user);
            return user;
        }
        public bool DeleteUser(string userName)
        {

          
            using var dbcontext = new MyDbContext();

           
            var user = dbcontext.users.FirstOrDefault(o => o.UserName == userName);
            if (user != null)
            {
                dbcontext.users.Remove(user);
                dbcontext.SaveChanges();
                return true;

            }
            return false; 

        }
        public UserEntity CreateUser(UserEntity userData)
        {
            using var dbcontext = new MyDbContext();

            dbcontext.users.Add(userData);

            int number_rows = dbcontext.SaveChanges();

            if (number_rows > 0) return userData;
            return null;
            
        }

    }

}

