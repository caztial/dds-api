namespace WebAPI.Endpoints.AccountEndpoints
{
    public class VerifyByNameAccountRequest
    {
        public const string Route = "Account/VerifyByName";
        public string AccountName { get; set; }
    }
}