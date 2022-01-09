using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Endpoints.AgentEndpoints;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class Create : BaseAsyncEndpoint.WithRequest<CreateAgentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _repository;
        private readonly IAccountService _accountService;
        public Create(IRepository<Agent> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        [HttpPost("/Agent")]
        [SwaggerOperation(
            Summary = "Create a new Agent",
            Description = "Create a new Agent",
            OperationId = "Agent.Create",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync(CreateAgentRequest request, CancellationToken cancellationToken = default)
        {
            if (request.Name == null || request.Name == "")
            {
                return BadRequest();
            }

            Agent newAgent = new(request.Name);
            newAgent.Coordinator = request.Coordinator;
            newAgent.Phone = request.Phone;
            newAgent.GroupId = request.GroupId;

            return await _repository.AddAsync(newAgent,cancellationToken);
        }
    }
}
