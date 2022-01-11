using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CreateAssignment : BaseAsyncEndpoint.WithRequest<CreateAssignmentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _agentRepository;
        private readonly IRepository<Account> _accountRepository;
        public CreateAssignment(IRepository<Agent> agentRepository, IRepository<Account> accountRepository)
        {
            _agentRepository = agentRepository;
            _accountRepository = accountRepository;
        }

        [HttpPost(CreateAssignmentRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Create new assignemnt to Agent",
            Description = "Create new assignemnt to Agent",
            OperationId = "Agent.CreateAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute]CreateAssignmentRequest request, CancellationToken cancellationToken = default)
        {
            ListAgentByIdSpec spec = new ListAgentByIdSpec(request.AgentId,true);
            Agent agent = await _agentRepository.GetBySpecAsync(spec, cancellationToken);
            GetAccountByIdSpec accountSpec = new GetAccountByIdSpec(request.AccountId);
            Account account = await _accountRepository.GetBySpecAsync(accountSpec, cancellationToken);
            
            if(agent == null || account == null)
            {
                return BadRequest("Invalid AgentId or AccountId");
            }

            if(account.AgentAssignment!=null)
            {
                return Conflict("Assignemnt Already Exist");
            }

            agent.AllocateAssignment(account.Id);
            await _agentRepository.UpdateAsync(agent);
            return Ok(agent);
        }
    }
}
