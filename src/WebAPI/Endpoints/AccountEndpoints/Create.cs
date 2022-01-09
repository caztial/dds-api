using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateAccountRequest>.WithResponse<Account>
    {
        private readonly IRepository<Account> _repository;
        private readonly IAccountService _accountService;
        public Create(IRepository<Account> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        [HttpPost("/Account")]
        [SwaggerOperation(
            Summary = "Create a new Account",
            Description = "Create a new Account",
            OperationId = "Account.Create",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<Account>> HandleAsync(CreateAccountRequest request, CancellationToken cancellationToken = default)
        {
            if(request.Name == null || request.Name == "")
            {
                return BadRequest();
            }
            if (await _accountService.IsDuplicateAccount(request.Name))
            {
                return Conflict();
            }

            bool verify = false;
            if (request.IsVerified != null && request.IsVerified == true)
            {
                verify = true;
            }
            Account newAccount = new(request.Name, verify);
            return await _repository.AddAsync(newAccount, cancellationToken);
        }
    }
}
