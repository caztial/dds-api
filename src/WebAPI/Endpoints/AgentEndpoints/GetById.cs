using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class GetById : BaseAsyncEndpoint.WithRequest<GetAgentByIdRequest>.WithResponse<Agent>
    {
        private readonly IReadRepository<Agent> _repository;
        public GetById(IReadRepository<Agent> readRepository)
        {
            _repository = readRepository;
        }

        [HttpGet(GetAgentByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Get Agent by Id",
            Description = "Get Agent by Id",
            OperationId = "Agent.GetById",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute]GetAgentByIdRequest request, CancellationToken cancellationToken = default)
        {
            ListAgentByIdSpec spec = new(request.AgentId, request.Assignments);
            Agent agent = await _repository.GetBySpecAsync(spec, cancellationToken);
            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }
    }
}
