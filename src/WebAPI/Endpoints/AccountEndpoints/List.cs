using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class List : BaseAsyncEndpoint.WithRequest<ListAccountsRequest>.WithResponse<ListAccountResponse>
    {
        private readonly IReadRepository<Account> _repository;
        public List(IReadRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpGet("/Account")]
        [SwaggerOperation(
            Summary = "List Accounts",
            Description = "List All Account",
            OperationId = "Account.List",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountResponse>> HandleAsync([FromQuery]ListAccountsRequest request, CancellationToken cancellationToken = default)
        {
            var ListAccountSpec = new ListAccountsSpec(request.Status,request.Take,request.Skip);
            List<Account> accounts = await _repository.ListAsync(ListAccountSpec, cancellationToken);
            int count = await _repository.CountAsync(ListAccountSpec,cancellationToken);
            if(accounts.Count == 0)
            {
                return NotFound();
            }
            return new ListAccountResponse { Accounts = accounts, TotalCount=count, Skip= request.Skip, Take=request.Take };

        }
    }
}
