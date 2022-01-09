using Ardalis.ApiEndpoints;
using Core.Entities;
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
        public override Task<ActionResult<Agent>> HandleAsync([FromRoute]GetAgentByIdRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
