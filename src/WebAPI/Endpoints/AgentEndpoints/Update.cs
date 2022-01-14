using Ardalis.ApiEndpoints;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class Update : BaseAsyncEndpoint.WithRequest<UpdateAgentRequest>.WithResponse<Agent>
    {
        private readonly IRepository<Agent> _repository;
        public Update(IRepository<Agent> repository)
        {
            _repository = repository;
        }

        [HttpPut(UpdateAgentRequest.Route)]
        [SwaggerOperation(
            Summary = "Update an existing Agent",
            Description = "Update an existing Agent",
            OperationId = "Agent.Update",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<Agent>> HandleAsync(UpdateAgentRequest request, CancellationToken cancellationToken = default)
        {
            Agent agent = await _repository.GetByIdAsync(request.AgentId);
            
            if(agent == null)
            {
                return NotFound();
            }

            agent.Name = request.Name;
            if(request.Password != null)
            {
                agent.Password = request.Password;
            }           
            agent.Phone = request.Phone;
            agent.GroupId = request.GroupId;
            agent.Coordinator = request.Coordinator;

            await _repository.UpdateAsync(agent,cancellationToken);

            return agent;
        }
    }
}
