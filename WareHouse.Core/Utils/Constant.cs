namespace WareHouse.Core.Utils
{
    public class Constant
    {
        public const string API_BASE = "api/v1";
        public const string INVALID_USER_CREDENTIALS = "INVALID_USER_CREDENTIALS";

        public const string GET_LIST_PERMISSIONS_SUCCESSFULLY = "GET_LIST_PERMISSIONS_SUCCESSFULLY";
        public const string GET_LIST_PERMISSIONS_FAILED = "GET_LIST_PERMISSIONS_FAILED";

        public const string DELETE_USER_SUCCESSFULLY = "DELETE_USER_SUCCESSFULLY";
        public const string DELETE_USER_FAILED = "DELETE_USER_FAILED";

        public const string CREATE_USER_SUCCESSFULLY = "CREATE_USER_SUCCESSFULLY";
        public const string CREATE_USER_FAILED = "CREATE_USER_FAILED";

        public const string UPDATE_USER_SUCCESSFULLY = "UPDATE_USER_SUCCESSFULLY";
        public const string UPDATE_USER_FAILED = "UPDATE_USER_FAILED";

        public const string GET_USER_SUCCESSFULLY = "GET_USER_SUCCESSFULLY";
        public const string GET_USER_FAILED = "GET_USER_FAILED";

        public const string GET_ALL_USERS_SUCCESSFULLY = "GET_ALL_USERS_SUCCESSFULLY";
        public const string GET_ALL_USERS_FAILED = "GET_ALL_USERS_FAILED";

        public const string CHANGE_PASSWORD_SUCCESSFULLY = "CHANGE_PASSWORD_SUCCESSFULLY";
        public const string CHANGE_PASSWORD_FAILED = "CHANGE_PASSWORD_FAILED";

        public const string SYSTEM_EMAIL_ADDRESS = "trungvippro10x123@gmail.com";
        public const string SYSTEM_EMAIL_PASSWORD = "trungtt123";

        public const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public const string USER_ALREADY_EXISTS = "USER_ALREADY_EXISTS";
        public const string INVALID_INPUT = "INVALID_INPUT";
        public const string USERNAME_OR_PASSWORD_IS_INCORRECT = "USERNAME_OR_PASSWORD_IS_INCORRECT";
        public const string AUTHENTICATION_SUCCESSFULLY = "AUTHENTICATION_SUCCESSFULLY";
        public const string DEFAULT_PASSWORD = "123456";
        public const int RANDOM_DEFAULT_PASSWORD_LENGTH = 6;


        public const string Administrator = "1";
        public const string Manager = "2";
        public const string Stocker = "3";



        public const string CONNECTION_STRING = @"
                Data Source=DESKTOP-834K9VO;
                Initial Catalog=DBWAREHOUSE;
                Integrated Security=True;
                Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";
    }
}
