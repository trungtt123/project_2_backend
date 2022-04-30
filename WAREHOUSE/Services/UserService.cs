using WAREHOUSE.Models;
using WAREHOUSE.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WAREHOUSE.Entities;
using WAREHOUSE.Utils;
using AutoMapper;
namespace WAREHOUSE.Services
{
    public interface IUserService
    {

        public UserInfomation GetUserFromUserName(string userName);

        public UserInfomation CreateUser(User userData);
        public UserInfomation DeleteUser(string userName);

        public UserDto Authenticate(UserLogin userLogin);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHelpers _helpers;
        private readonly IConfiguration _iconfiguration;
        public UserService(IUserRepository userRepository, IHelpers helpers, IConfiguration iconfiguration)
        {
            _userRepository = userRepository;
            _helpers = helpers;
            _iconfiguration = iconfiguration;
        }

        public UserInfomation GetUserFromUserName(string userName)
        {
            var userInfomation = new UserInfomation { Message = Constant.INVALID_INPUT };
            var userEntity = new UserEntity();
            if (!_helpers.CheckEmptyOrNullUserData(userName))
            {
                userEntity = _userRepository.GetUser(userName);
                if (userEntity != null)
                {

                   
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(new MappingProfile());
                    });
                    var mapper = config.CreateMapper();

                    userInfomation = mapper.Map<UserEntity, UserInfomation>(userEntity);
                    userInfomation.Message = Constant.GET_USER_SUCCESSFULLY;
                }
                else return new UserInfomation{ Message = Constant.USER_NOT_FOUND };
            }
            return userInfomation;
        }

        public UserInfomation CreateUser(User userData)
        {
            var userInfomation = new UserInfomation();
            var userEntity = new UserEntity();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            userEntity = mapper.Map<User, UserEntity>(userData);


            string hashPassWord = _helpers.GetHashPassWord(userData.PassWord);

            userEntity.PassWord = hashPassWord;

            if (!_helpers.CheckValidUserData(userData))
            {
                bool kt = _userRepository.CheckUserNameAlreadyExists(userData.UserName);
                if (!kt)
                {
                    userEntity = _userRepository.CreateUser(userEntity);
                    if (userEntity != null) {

                        userInfomation = mapper.Map<UserEntity, UserInfomation>(userEntity);
                        userInfomation.Message = Constant.CREATE_USER_SUCCESSFULLY;
                        return userInfomation;
                    }
                    else return new UserInfomation { Message = Constant.CREATE_USER_FAILED};
                }
                else return new UserInfomation { Message = Constant.USER_ALREADY_EXISTS };   
            }
            else userInfomation.Message = Constant.INVALID_INPUT;
            return userInfomation;
        }
        public UserInfomation DeleteUser(string userName)
        {

            var res = new UserInfomation { Message = Constant.INVALID_INPUT };
            if (!_helpers.CheckEmptyOrNullUserData(userName))
            {
                var kt = _userRepository.DeleteUser(userName);
                if (kt)
                {
                    res.Message = Constant.DELETE_USER_SUCCESSFULLY;
                }
                else res.Message = Constant.DELETE_USER_FAILED;
            }
            return res;
        }
        public UserDto Authenticate(UserLogin userLogin)
        {

            var user = _userRepository.GetUser(userLogin.UserName);

            bool isValidPassWord = _helpers.IsValidPassWord(userLogin.PassWord, user.PassWord);

            if (!isValidPassWord || user == null) return null;

            var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),

            new Claim(ClaimTypes.GivenName, user.GivenName),

            new Claim(ClaimTypes.Surname, user.SurName),

            new Claim(ClaimTypes.Role, user.Role),

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

            userDto.Message = Constant.AUTHENTICATION_SUCCESSFULLY;

            return userDto;
        }
    }
}