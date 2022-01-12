using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class List : BaseAsyncEndpoint.WithoutRequest.WithResponse<List<Agent>>
    {
        private readonly IReadRepository<Agent> _repository;
        public List(IReadRepository<Agent> readRepository)
        {
            _repository = readRepository;
        }

        [HttpGet("/Agent")]
        [SwaggerOperation(
            Summary = "List all Agents",
            Description = "List all Agent",
            OperationId = "Agent.List",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<List<Agent>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            ListAgentWithGroupSpec agentWithGroupSpec = new();
            return await _repository.ListAsync(agentWithGroupSpec);
        }

    }
}
