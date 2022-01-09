using Ardalis.ApiEndpoints;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.GroupEndpoints
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<List<Group>>
    {
        private readonly IReadRepository<Group> _repository;

        public List(IReadRepository<Group> repository)
        {
            _repository = repository;
        }
        [HttpGet("/Group")]
        [SwaggerOperation(
            Summary = "List Groups",
            Description = "List All Groups",
            OperationId = "Group.List",
            Tags = new[] { "GroupEndpoints" })
        ]
        public async override Task<ActionResult<List<Group>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.ListAsync(cancellationToken);
        }
    }
}
