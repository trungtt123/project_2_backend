namespace WAREHOUSE.Utils
{
    public class Constant
    {
        public const string INVALID_USER_CREDENTIALS = "INVALID_USER_CREDENTIALS";
        public const string DELETE_USER_SUCCESSFULLY = "DELETE_USER_SUCCESSFULLY";
        public const string DELETE_USER_FAILED = "DELETE_USER_FAILED";
        public const string CREATE_USER_SUCCESSFULLY = "CREATE_USER_SUCCESSFULLY";
        public const string GET_USER_SUCCESSFULLY = "GET_USER_SUCCESSFULLY";
        public const string GET_USER_FAILED = "GET_USER_FAILED";
        public const string CREATE_USER_FAILED = "CREATE_USER_FAILED";
        public const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public const string USER_ALREADY_EXISTS = "USER_ALREADY_EXISTS";
        public const string INVALID_INPUT = "INVALID_INPUT";
        public const string USERNAME_OR_PASSWORD_IS_INCORRECT = "USERNAME_OR_PASSWORD_IS_INCORRECT";
        public const string AUTHENTICATION_SUCCESSFULLY = "AUTHENTICATION_SUCCESSFULLY";



        public const string Administrator = "Administrator";
        public const string Manager = "Manager";
        public const string Stocker = "Stocker";


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
