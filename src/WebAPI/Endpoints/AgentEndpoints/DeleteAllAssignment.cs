using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class DeleteAllAssignment : BaseAsyncEndpoint.WithoutRequest.WithoutResponse
    {
        private readonly IRepository<Agent> _agentRepository;
        public DeleteAllAssignment(IRepository<Agent> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpDelete("Agent/DeleteAll")]
        [SwaggerOperation(
            Summary = "WARNING !! - Delete all assignemnts of Agents",
            Description = "WARNING !! - Delete assignemnts of an Agents",
            OperationId = "Agent.DeleteAllAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]

        public async override Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            List<Agent> agents = await _agentRepository.ListAsync(cancellationToken);
            foreach (Agent i in agents)
            {
                GetAgentByIdSpec getAgentByIdSpec = new GetAgentByIdSpec(i.Id, true);
                Agent agent = await _agentRepository.GetBySpecAsync(getAgentByIdSpec, cancellationToken);
                foreach (var item in agent.Assignments.ToList())
                {
                    agent.RemoveAssignment(item.Id);
                }
                await _agentRepository.UpdateAsync(agent, cancellationToken);
            }
            throw new NotImplementedException();
        }
    }
}
