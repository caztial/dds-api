namespace WebAPI.Endpoints.AccountEndpoints
{
    public class UpdateAccountRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
    }
}