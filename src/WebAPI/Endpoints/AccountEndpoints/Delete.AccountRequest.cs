namespace WebAPI.Endpoints.AccountEndpoints
{
    public class DeleteAccountRequest
    {
        public const string ROUTE = "/Account/{AccountId}";
        public int AccountId { get; set; }
    }
}