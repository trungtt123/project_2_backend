using WareHouse.Core.Models;
using WareHouse.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WareHouse.Core.Entities;
using WareHouse.Core.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WareHouse.Service.Interfaces;

namespace WareHouse.Service.Implementations
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _iconfiguration;
        public UserService(IUserRepository userRepository, IConfiguration iconfiguration)
        {
            _userRepository = userRepository;
            _iconfiguration = iconfiguration;
        }
        public List<UserData> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            List<UserData> arr = mapper.Map<List<UserEntity>, List<UserData>>(users);
            return arr;
        }
        public UserDto Authenticate(UserLogin userLogin)
        {

            var user = _userRepository.GetUser(userLogin.UserName);

            bool isValidPassWord = Helpers.IsValidPassWord(userLogin.PassWord, user.PassWord);

            if (!isValidPassWord || user == null) return null;

            var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),

            new Claim(ClaimTypes.GivenName, user.GivenName),

            new Claim(ClaimTypes.Surname, user.SurName),

            new Claim(ClaimTypes.Role, user.RoleId.ToString()),

        };
            var token = new JwtSecurityToken
            (
                issuer: _iconfiguration["Jwt:Issuer"],
                audience: _iconfiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            UserDto userDto = mapper.Map<UserEntity, UserDto>(user);

            userDto.Token = tokenString;

            userDto.RoleId = user.RoleId;

            return userDto;
        }
        public List<UserInfomation> AddUser(List<UserNoId> users)
        {
            foreach (var user in users)
            {
                var tmp = users.FindAll(o => o.UserName == user.UserName);
                if (tmp.Count > 1) return null;
                var userTmp = _userRepository.GetUser(user.UserName);
                if (userTmp != null) return null;
            }
            List<UserEntity> listUserEntity;
            List<UserInfomation> listUserInfomation;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            listUserEntity = mapper.Map<List<UserNoId>, List<UserEntity>>(users);
            listUserInfomation = mapper.Map<List<UserNoId>, List<UserInfomation>>(users);

            for (int i = 0; i < listUserEntity.Count; i++)
            {
                string passWord = Helpers.RandomString(Constant.RANDOM_DEFAULT_PASSWORD_LENGTH);
                listUserInfomation[i].PassWord = passWord;
                listUserEntity[i].PassWord = Helpers.GetHashPassWord(passWord);
            }
            var arr = _userRepository.AddUser(listUserEntity);
            if (arr != null)
            {
                for (int i = 0; i < listUserEntity.Count; i++)
                {
                  
                    listUserInfomation[i].UserId = arr[i].UserId;
                   
                }
                return listUserInfomation;
            }
            return null;
        }

        public List<UserInfomation> UpdateUser(List<UserUpdate> newUsers)
        {
            foreach (var user in newUsers)
            {
                var tmp = newUsers.FindAll(o => o.UserId == user.UserId);
                if (tmp.Count > 1) return null;
            }

            List<UserEntity> listUserEntity;
            List<UserInfomation> listUserInfomation;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            listUserEntity = mapper.Map<List<UserUpdate>, List<UserEntity>>(newUsers);
            listUserInfomation = mapper.Map<List<UserUpdate>, List<UserInfomation>>(newUsers);

            var arr = _userRepository.UpdateUser(listUserEntity); 
            if (arr != null)
            {
                return listUserInfomation;
            }
            return null;
        }

        public bool DeleteUser(List<int> listUserId)
        {
            foreach (var userId in listUserId)
            {
                var tmp = listUserId.FindAll(o => o == userId);
                if (tmp.Count > 1) return false;
            }
            var kt = _userRepository.DeleteUser(listUserId);
            return kt;
        }
        public List<RoleDto> GetListPermissions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            List<RoleEntity> arrPermissionEntity = _userRepository.GetListPermissions();
            List<RoleDto> arrPermissionDto = mapper.Map<List<RoleEntity>, List<RoleDto> >(arrPermissionEntity);
            return arrPermissionDto;
        }
        public bool ChangePassWord(UserChangePassWord userData)
        {
            var user = _userRepository.GetUser(userData.UserName);

            bool isValidPassWord = Helpers.IsValidPassWord(userData.OldPassWord, user.PassWord);

            if (!isValidPassWord || user == null) return false;

            bool kt = _userRepository.ChangePassWord(user.UserId, Helpers.GetHashPassWord(userData.NewPassWord)); 

            return kt;
        }
    }
}