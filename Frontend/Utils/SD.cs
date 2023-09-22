namespace Frontend.Utils
{
    public class SD
    {
        public const string TokenCookie = "JWTToken";
        public static string AuthAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
