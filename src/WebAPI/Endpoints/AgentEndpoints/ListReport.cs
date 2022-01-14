using Ardalis.ApiEndpoints;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.ApiModels;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class ListReport : BaseAsyncEndpoint.WithoutRequest.WithResponse<List<AgentReportDTO>>
    {
        private readonly IReadRepository<Agent> _repository;
        public ListReport(IReadRepository<Agent> readRepository)
        {
            _repository = readRepository;
        }

        [HttpGet("/Agent/Report")]
        [SwaggerOperation(
            Summary = "Get Agent Report",
            Description = "Get Agent Report",
            OperationId = "Agent.AgentReport",
            Tags = new[] { "AgentEndpoints" })
        ]
        public async override Task<ActionResult<List<AgentReportDTO>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            List<AgentReportDTO> response = new();
            ListAgentWithAllSpec agentWithGroupSpec = new();
            var agents = await _repository.ListAsync(agentWithGroupSpec);
            foreach (Agent agent in agents)
            {
                AgentReportDTO agentReportDTO = new AgentReportDTO
                {
                    Id = agent.Id,
                    Name= agent.Name,
                    Group= agent.Group.Name,
                    Coordinator = agent.Coordinator,
                    Phone = agent.Phone,
                    Assigned = agent.Assignments.Count(),
                    Complete = agent.Assignments.Where(a=>a.Status).Count()

                };
                response.Add(agentReportDTO);
                
            }
            return response;
        }

    }
}
