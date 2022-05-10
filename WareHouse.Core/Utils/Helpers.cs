using WareHouse.Core.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
        public static bool CheckEmptyOrNullUserData(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord)) return true;
            return false;
        }


        
        public static bool CheckEmptyOrNullUserData(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return true;
            return false;
        }
        public static bool CheckValidUserData(UserNoId userData)
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

        public static string GetHashPassWord(string passWord)
        {
            string passWordHashed = BCrypt.Net.BCrypt.HashPassword(passWord);
            return passWordHashed;
        }

        public static bool IsValidPassWord(string oPassWord, string passWord)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(oPassWord, passWord);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
