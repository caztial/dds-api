using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class DeleteByName : BaseAsyncEndpoint.WithRequest<DeleteByNameAccountRequest>.WithResponse<Boolean>
    {
        private readonly IRepository<Account> _repository;

        public DeleteByName(IRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteByNameAccountRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Delete a existing Account",
            Description = "Delete a existing Account",
            OperationId = "Account.DeleteByName",
            Tags = new[] { "AccountEndpoints" })
        ]
        public async override Task<ActionResult<bool>> HandleAsync([FromQuery] DeleteByNameAccountRequest request, CancellationToken cancellationToken = default)
        {
            GetAccountByNameSpec getAccoutByNameSpec = new(request.AccountName);
            Account? account = await _repository.GetBySpecAsync(getAccoutByNameSpec, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(account, cancellationToken);
            return Ok(true);
        }
    }
}
