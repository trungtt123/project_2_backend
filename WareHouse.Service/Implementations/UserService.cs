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

            var user = _userRepository.GetUser(userLogin.UserName);

            if (user == null) return null;

            bool isValidPassWord = Helpers.IsValidPassWord(userLogin.Password, user.Password);

            if (!isValidPassWord) return null;

            var claims = new[]
        {
            new Claim("username", user.UserName),

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

            userDto.Token = tokenString;

            userDto.RoleId = user.RoleId;

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
            var userTmp = _userRepository.GetUser(user.UserName);
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
                    EmailFrom = Constant.SYSTEM_EMAIL_ADDRESS, 
                    EmailTo = user.Email, 
                    Subject = "Create Account Successfully", 
                    Body = "Username: <b>" + user.UserName + "</b> <br /> Password: <b>" + password + "</b>" 
                };
                var systemEmail = new EmailAccountDto { EmailAddress = Constant.SYSTEM_EMAIL_ADDRESS, Password = Constant.SYSTEM_EMAIL_PASSWORD };
                var task = _mailService.SendMail(email, systemEmail);
                task.Wait();
                var kt = task.Result;
                if (!kt) return null;

                userInfomation.UserId = userResponse.UserId;
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
            
            var user = _userRepository.GetUser(userData.UserName);

            if (user == null) return false;

            bool isValidPassWord = Helpers.IsValidPassWord(userData.OldPassword, user.Password);

            if (!isValidPassWord) return false;

            bool kt = _userRepository.ChangePassWord(user.UserId, Helpers.GetHashPassword(userData.NewPassword));

            return kt;
        }
    

    }
}