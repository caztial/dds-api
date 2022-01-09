using Ardalis.ApiEndpoints;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.GroupEndpoints
{
    public class Create: BaseAsyncEndpoint.WithRequest<CreateGroupRequest>.WithResponse<Group>
    {
        private readonly IRepository<Group> _repository;

        public Create(IRepository<Group> repository)
        {
            _repository = repository;
        }

        [HttpPost("/Group")]
        [SwaggerOperation(
            Summary = "Create a new Group",
            Description = "Create a new Grou[",
            OperationId = "Group.Create",
            Tags = new[] { "GroupEndpoints" })
        ]
        public async override Task<ActionResult<Group>> HandleAsync(CreateGroupRequest request, CancellationToken cancellationToken = default)
        {
           if(request.Name == "")
           {
                return BadRequest();
           }
           Group newGroup = new (request.Name);
           return await _repository.AddAsync(newGroup);
        }
    }
}
