using WAREHOUSE.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WAREHOUSE.Utils
{
    public interface IHelpers
    {
        public bool CheckEmptyOrNullUserData(string userName);
        public bool CheckEmptyOrNullUserData(string userName, string passWord);
        public bool CheckValidUserData(User userData);
        public string GetResponseStatus(string status);
        public string GetHashPassWord(string passWord);
        public bool IsValidPassWord(string oPassWord, string passWord);
    }

    public class Helpers : IHelpers
    {
        public bool CheckEmptyOrNullUserData(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord)) return true;
            return false;
        }


        
        public bool CheckEmptyOrNullUserData(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return true;
            return false;
        }
        public bool CheckValidUserData(User userData)
        {
            if (string.IsNullOrEmpty(userData.UserName)
              || string.IsNullOrEmpty(userData.PassWord)
              || string.IsNullOrEmpty(userData.SurName)
              || string.IsNullOrEmpty(userData.GivenName)
              || string.IsNullOrEmpty(userData.Role)
              || 
              (userData.Role != Constant.Administrator 
              && userData.Role != Constant.Manager 
              && userData.Role != Constant.Stocker)
               ) return true;
            return false;
            
        }
        public string GetResponseStatus(string status)
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

        public string GetHashPassWord(string passWord)
        {
            string passWordHashed = BCrypt.Net.BCrypt.HashPassword(passWord);
            return passWordHashed;
        }

        public bool IsValidPassWord(string oPassWord, string passWord)
        {
            return BCrypt.Net.BCrypt.Verify(oPassWord, passWord);
        }
    }
}
