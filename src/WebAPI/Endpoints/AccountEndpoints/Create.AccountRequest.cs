namespace WebAPI.Endpoints.AccountEndpoints
{
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public bool? IsVerified { get; set; }
    }
}