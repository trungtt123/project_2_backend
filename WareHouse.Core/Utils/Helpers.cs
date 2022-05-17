using WareHouse.Core.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace WareHouse.Core.Utils
{
    public class Helpers
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool CheckEmptyOrNullUserData(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) return true;
            return false;
        }


        
        public static bool CheckEmptyOrNullUserData(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return true;
            return false;
        }
        public static bool CheckValidUserData(UserNoIdDto userData)
        {
            if (string.IsNullOrEmpty(userData.UserName)
              || string.IsNullOrEmpty(userData.SurName)
              || string.IsNullOrEmpty(userData.GivenName)

               ) return true;
            return false;
            
        }
        public static string GetResponseStatus(string status)
        {
            if (
                   status == Constant.INVALID_INPUT
                || status == Constant.INVALID_USER_CREDENTIALS
                || status == Constant.USER_NOT_FOUND
                || status == Constant.USER_ALREADY_EXISTS
                || status == Constant.USERNAME_OR_PASSWORD_IS_INCORRECT
                || status == Constant.GET_USER_FAILED

               ) return "400";
            if (
                   status == Constant.CREATE_USER_SUCCESSFULLY
                || status == Constant.DELETE_USER_SUCCESSFULLY
                || status == Constant.GET_USER_SUCCESSFULLY

                ) return "200";
            return "200";

        }

        public static string GetHashPassword(string password)
        {
            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHashed;
        }

        public static bool IsValidPassWord(string oPassword, string password)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(oPassword, password);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static string DecodeJwt(string jwt, string type)
        {
            
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = jsonToken as JwtSecurityToken;
            var data = tokenS.Claims.First(claim => claim.Type == type).Value;
            return data;
        }

        public static object SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
