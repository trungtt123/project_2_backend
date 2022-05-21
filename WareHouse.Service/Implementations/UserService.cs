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
using System.Net.Mail;

namespace WareHouse.Service.Implementations
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _iconfiguration;
        private readonly IMailService _mailService;
        public UserService(IUserRepository userRepository, IConfiguration iconfiguration, IMailService mailService)
        {
            _userRepository = userRepository;
            _iconfiguration = iconfiguration;
            _mailService = mailService;
        }
        public bool VerifyToken(string token)
        {
            try
            {
                var userId = Int32.Parse(Helpers.DecodeJwt(token, "userid"));
                var roleId = Int32.Parse(Helpers.DecodeJwt(token, "role"));
                var user = _userRepository.GetUser(userId);
               
                
                if (user == null || user.RoleId != roleId) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<UserDataDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            List<UserDataDto> arr = mapper.Map<List<UserEntity>, List<UserDataDto>>(users);
            return arr;
        }
        public UserDto Authenticate(UserLoginDto userLogin)
        {

            var user = _userRepository.GetUser(userLogin.userName);

            if (user == null) return null;

            bool isValidPassWord = Helpers.IsValidPassWord(userLogin.password, user.Password);

            if (!isValidPassWord) return null;

            var claims = new[]
        {
            

            new Claim("username", user.UserName),

            new Claim("userid", user.UserId.ToString()),

            new Claim("givenname", user.GivenName),

            new Claim("surname", user.SurName),

            new Claim("role", user.RoleId.ToString()),

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

            userDto.token = tokenString;

            userDto.roleId = user.RoleId;

            return userDto;
        }

        public UserInfomationDto GetUser(int userId)
        {
            UserEntity user = _userRepository.GetUser(userId);

            if (user == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var userInfomation = mapper.Map<UserEntity, UserInfomationDto>(user);

            return userInfomation;
        }
        public UserInfomationDto CreateUser(UserNoIdDto user)
        {
            var userTmp = _userRepository.GetUser(user.userName);
            if (userTmp != null) return null;

            UserEntity userEntity;
            UserInfomationDto userInfomation;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            userEntity = mapper.Map<UserNoIdDto, UserEntity>(user);
            userInfomation = mapper.Map<UserNoIdDto, UserInfomationDto>(user);

            string password = Helpers.RandomString(Constant.RANDOM_DEFAULT_PASSWORD_LENGTH);


            //call api google

            userEntity.Password = Helpers.GetHashPassword(password);
            
            var userResponse = _userRepository.CreateUser(userEntity);
            if (userResponse != null)
            {

                var email = new EmailFormDto 
                { 
                    emailFrom = Constant.SYSTEM_EMAIL_ADDRESS, 
                    emailTo = user.email, 
                    subject = "Create Account Successfully", 
                    body = "Username: <b>" + user.userName + "</b> <br /> Password: <b>" + password + "</b>" 
                };
                var systemEmail = new EmailAccountDto { emailAddress = Constant.SYSTEM_EMAIL_ADDRESS, password = Constant.SYSTEM_EMAIL_PASSWORD };
                var task = _mailService.SendMail(email, systemEmail);
                task.Wait();
                var kt = task.Result;
                if (!kt) return null;

                userInfomation.userId = userResponse.UserId;
                return userInfomation;
            }
            return null;
        }

        public bool UpdateUser(UserUpdateDto newUserData)
        {
            

            UserEntity userEntity;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            userEntity = mapper.Map<UserUpdateDto, UserEntity>(newUserData);
           

            return _userRepository.UpdateUser(userEntity);

        }

        public bool DeleteUser(int userId)
        {
      
            return _userRepository.DeleteUser(userId);

        }
        public List<RoleDto> GetListPermissions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            List<RoleEntity> arrPermissionEntity = _userRepository.GetListPermissions();
            List<RoleDto> arrPermissionDto = mapper.Map<List<RoleEntity>, List<RoleDto>>(arrPermissionEntity);
            return arrPermissionDto;
        }
        public bool ChangePassWord(UserChangePassWordDto userData)
        {
            
            var user = _userRepository.GetUser(userData.userName);

            if (user == null) return false;

            bool isValidPassWord = Helpers.IsValidPassWord(userData.oldPassword, user.Password);

            if (!isValidPassWord) return false;

            bool kt = _userRepository.ChangePassWord(user.UserId, Helpers.GetHashPassword(userData.newPassword));

            return kt;
        }
    

    }
}