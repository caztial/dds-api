using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateAccountRequest>.WithResponse<Account>
    {
        private readonly IRepository<Account> _repository;
        private readonly IAccountService _accountService;
        public Update(IRepository<Account> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        [HttpPut("/Account")]
        [SwaggerOperation(
            Summary = "Update a existing Account",
            Description = "Update a existing Account",
            OperationId = "Account.Update",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<Account>> HandleAsync(UpdateAccountRequest request, CancellationToken cancellationToken = default)
        {
            Account? account = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if(account == null)
            {
                return NotFound();
            }
            if(request.Name != account.Name )
            {
                if (!await _accountService.IsDuplicateAccount(request.Name))
                {
                    account.Name = request.Name;
                }
                else
                {
                    return Conflict();
                }
            }
            if (request.IsVerified)
            {
                account.VerifyAccount();
            }
            return Ok(account);
        }

    }
}
