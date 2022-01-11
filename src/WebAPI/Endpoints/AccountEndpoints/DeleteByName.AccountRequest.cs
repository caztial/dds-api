namespace WebAPI.Endpoints.AccountEndpoints
{
    public class DeleteByNameAccountRequest
    {
        public const string ROUTE = "/Account/DeleteByName";
        public string AccountName { get; set; }
    }
}