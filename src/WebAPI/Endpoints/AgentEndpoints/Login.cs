using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class Login : BaseAsyncEndpoint.WithRequest<LoginRequest>.WithResponse<Agent>
    {
        private readonly IReadRepository<Agent> _repository;
        public Login(IReadRepository<Agent> readRepository)
        {
            _repository = readRepository;
        }

        [HttpPost("/Agent/Login")]
        [SwaggerOperation(
            Summary = "List all Agents",
            Description = "List all Agent",
            OperationId = "Agent.List",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            GetAgentByUsernameSpec agentByUsernameSpec = new GetAgentByUsernameSpec(request.Username,true);
            Agent? agent = await _repository.GetBySpecAsync(agentByUsernameSpec);
            
            if (agent == null || !agent.CheckUsernameAndPassword(request.Username, request.Password))
            {
                return BadRequest("Invalid Username or Password");
            }

            return Ok(agent);
        }
    }
}
