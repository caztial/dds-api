﻿using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class CompleteAssignment : BaseAsyncEndpoint.WithRequest<UpdateAssignmentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _agentRepository;
        public CompleteAssignment(IRepository<Agent> agentRepository)
        {
            _agentRepository = agentRepository;
        }

        [HttpPatch(UpdateAssignmentRequest.COMPLETE_ROUTE)]
        [SwaggerOperation(
            Summary = "Complete assignemnt of an Agent",
            Description = "Complete assignemnt of an Agent",
            OperationId = "Agent.CompleteAssignment",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync([FromRoute] UpdateAssignmentRequest request, CancellationToken cancellationToken = default)
        {
            ListAgentByIdSpec spec = new(request.AgentId, true);
            Agent agent = await _agentRepository.GetBySpecAsync(spec, cancellationToken);

            if (agent == null)
            {
                return BadRequest("Invalid AgentId");
            }

            if (!agent.UpdateAssignemntStatus(request.AssignmentId,true))
            {
                return NotFound();
            }

            await _agentRepository.UpdateAsync(agent);
            return Ok(agent);
        }
    }

}
