using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CreateAutoAssignment : BaseAsyncEndpoint.WithRequest<CreateAutoAssignmentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _agentRepository;
        private readonly IRepository<Account> _accountRepository;
        public CreateAutoAssignment(IRepository<Agent> agentRepository, IRepository<Account> accountRepository)
        {
            _agentRepository = agentRepository;
            _accountRepository = accountRepository;
        }

        [HttpPost(CreateAutoAssignmentRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Create new Auto assignemnt to Agent",
            Description = "Create new Auto assignemnt to Agent",
            OperationId = "Agent.CreateAutoAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute] CreateAutoAssignmentRequest request, CancellationToken cancellationToken = default)
        {
            GetAgentByIdSpec spec = new GetAgentByIdSpec(request.AgentId, true);
            Agent agent = await _agentRepository.GetBySpecAsync(spec, cancellationToken);

            ListUnAssignedVerifiedAccounts accountSpec = new (request.Count);
            List<Account> accounts = await _accountRepository.ListAsync(accountSpec, cancellationToken);

            if (agent == null || accounts == null)
            {
                return BadRequest("Invalid AgentId or AccountId");
            }

            if (accounts.Count < 1)
            {
                return NotFound("No Unassigned Verified Accounts");
            }

            foreach (var item in accounts)
            {
                agent.AllocateAssignment(item.Id);
            }
            
            await _agentRepository.UpdateAsync(agent);
            return Ok(agent);
        }
    }
}
