using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.AgentEndpoints
{
    public class AssignmentStatusRequest
    {
        public const string ROUTE = "/Agent/{AgentId}/Assignment/{AssignmentId}";
        public int AgentId { get; set; }
        public int AssignmentId { get; set; }
        [FromQuery]
        public bool Status { get; set; }
    }
}