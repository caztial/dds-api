using Ardalis.ApiEndpoints;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AccountEndpoints
{
    public class Delete : BaseAsyncEndpoint.WithRequest<DeleteAccountRequest>.WithResponse<Boolean>
    {
        private readonly IRepository<Account> _repository;

        public Delete(IRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteAccountRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Delete a existing Account",
            Description = "Delete a existing Account",
            OperationId = "Account.Delete",
            Tags = new[] { "AccountEndpoints" })
        ]
        public async override Task<ActionResult<bool>> HandleAsync([FromRoute]DeleteAccountRequest request, CancellationToken cancellationToken = default)
        {
            Account? account = await _repository.GetByIdAsync(request.AccountId, cancellationToken);
            if (account == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(account, cancellationToken);
            return Ok(true);
        }
    }
}
