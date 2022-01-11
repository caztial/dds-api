using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class DeleteAssignment : BaseAsyncEndpoint.WithRequest<DeleteAssignmentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _agentRepository;
        public DeleteAssignment(IRepository<Agent> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpDelete(DeleteAssignmentRequest.ROUTE)]
        [SwaggerOperation(
            Summary = "Delete assignemnt of an Agent",
            Description = "Delete assignemnt of an Agent",
            OperationId = "Agent.DeleteAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute] DeleteAssignmentRequest request, CancellationToken cancellationToken = default)
        {
            ListAgentByIdSpec spec = new ListAgentByIdSpec(request.AgentId, true);
            Agent agent = await _agentRepository.GetBySpecAsync(spec, cancellationToken);
 
            if (agent == null)
            {
                return BadRequest("Invalid AgentId");
            }

            if (!agent.RemoveAssignment(request.AssignmentId))
            {
                return NotFound();
            }

            await _agentRepository.UpdateAsync(agent);
            return Ok();
        }
    }

}
