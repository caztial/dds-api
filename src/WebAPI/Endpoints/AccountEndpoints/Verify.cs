using Ardalis.ApiEndpoints;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class Verify: BaseAsyncEndpoint.WithRequest<VerifyAccountRequest>.WithResponse<Account>
    {
        private readonly IRepository<Account> _repository;

        public Verify(IRepository<Account> repository)
        {
            _repository=repository;
        }

        [HttpPatch(VerifyAccountRequest.Route)]
        [SwaggerOperation(
            Summary = "Verify a existing Account",
            Description = "Verify a existing Account",
            OperationId = "Account.Verify",
            Tags = new[] { "AccountEndpoints" })
        ]
        public async override Task<ActionResult<Account>> HandleAsync([FromRoute]VerifyAccountRequest request, CancellationToken cancellationToken = default)
        {
            Account? account = await _repository.GetByIdAsync(request.AccountId, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            account.VerifyAccount();

            return Ok(account);
        }
    }
}
