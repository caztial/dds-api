using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class VerifyByName : BaseAsyncEndpoint.WithRequest<VerifyByNameAccountRequest>.WithResponse<Account>
    {
        private readonly IRepository<Account> _repository;

        public VerifyByName(IRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpPatch(VerifyByNameAccountRequest.Route)]
        [SwaggerOperation(
            Summary = "Verify a existing Account",
            Description = "Verify a existing Account",
            OperationId = "Account.VerifyByName",
            Tags = new[] { "AccountEndpoints" })
        ]
        public async override Task<ActionResult<Account>> HandleAsync([FromQuery] VerifyByNameAccountRequest request, CancellationToken cancellationToken = default)
        {
            GetAccountByNameSpec getAccoutByNameSpec = new(request.AccountName);
            Account? account = await _repository.GetBySpecAsync(getAccoutByNameSpec, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            account.VerifyAccount();
            await _repository.UpdateAsync(account, cancellationToken);
            return Ok(account);
        }
    }
}
