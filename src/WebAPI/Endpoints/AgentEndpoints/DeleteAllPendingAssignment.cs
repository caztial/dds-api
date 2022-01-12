using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class DeleteAllPendingAssignment : BaseAsyncEndpoint.WithRequest<DeleteAllPendingAssignmentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _agentRepository;
        public DeleteAllPendingAssignment(IRepository<Agent> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpDelete(DeleteAllPendingAssignmentRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Delete all pending assignemnt of an Agent",
            Description = "Delete all pending assignemnt of an Agent",
            OperationId = "Agent.DeleteAllPendingAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute] DeleteAllPendingAssignmentRequest request, CancellationToken cancellationToken = default)
        {
            GetAgentByIdSpec spec = new GetAgentByIdSpec(request.AgentId, true);
            Agent agent = await _agentRepository.GetBySpecAsync(spec, cancellationToken);

            if (agent == null)
            {
                return BadRequest("Invalid AgentId");
            }

            if (agent.Assignments.Count()==0)
            {
                return NotFound();
            }

            foreach (var item in agent.Assignments.ToList())
            {
                if (!item.Status)
                {
                    agent.RemoveAssignment(item.Id);
                }
            }

            await _agentRepository.UpdateAsync(agent);
            return Ok();
        }
    }

}
