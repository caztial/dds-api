namespace WebAPI.Endpoints.AccountEndpoints
{
    public class VerifyAccountRequest
    {
        public const string Route = "Account/{AccountId}/verify";
        public int AccountId { get; set; }
    }
}