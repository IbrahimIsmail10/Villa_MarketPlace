
namespace Utility
{
    public class SD
    {
        public enum APITYPE
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string SessionToken = "JWTToken";
        public const string Admin = "admin";
        public const string Customer = "customer";

        public enum ContenType {
            Json,
            MultipartFormData,
        }

    }
}