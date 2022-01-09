using Core.Entities;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class ListAccountResponse
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public int TotalCount { get; set; } = 0; 


    }
}